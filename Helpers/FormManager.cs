using Ritrama2025.Services.ServiceLocator;

namespace Ritrama2025.Helpers
{
    public class FormManager()
    {
        private static readonly Dictionary<Type, Form> _forms = [];

        public static T? ShowForm<T>(Form mdiParent) where T : Form
        {
            var type = typeof(T);


            // verificar si ya existe y esta abierto
            if (_forms.TryGetValue(type, out var existingForm))
            {
                foreach (var xform in _forms.Values)
                {
                    xform.WindowState = FormWindowState.Normal; // evita que quede minimizado
                    xform.Show();                               // asegura que esté visible
                    xform.BringToFront();                       // lo trae al frente
                }
                return null;
            }
            //crear una nueva instancia usando DI
            
            var form = ServiceLocator.Get<T>();
            
            _forms[type] = form;

            foreach (var xform in _forms.Values)
            {
                xform.WindowState = FormWindowState.Normal; // evita que quede minimizado
                xform.Show();                               // asegura que esté visible
                xform.BringToFront();                       // lo trae al frente
            }


            form.FormClosed += (s, e) =>
            {
                _forms.Remove(type);
            };

            form.Show();
            return form;
        }

        public static void CleanupForm(Form form)
        {
            if (form == null || form.IsDisposed) return;
            Type formType = form.GetType();

            try
            {
                // Eliminar directamente sin verificar ContainsKey
                _forms.Remove(formType);

                form.Dispose();
                form.Close();
                form = null!;
                CloseAllForms();
            }
            catch (ObjectDisposedException)
            {
                throw;
            }
        }

        public static void CloseAllForms()
        {
            foreach (var form in new List<Form>(_forms.Values))
            {
                if (!form.IsDisposed)
                {
                    form.FormClosed -= (sender, e) => CleanupForm(form);
                    form.Close();
                }
            }

            _forms.Clear();
        }
    }
}
