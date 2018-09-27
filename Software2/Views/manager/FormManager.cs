using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SimpleInjector;
using Software2.Views;
using Software2.Views.manager;

namespace Software2
{
    public class FormManager : IFormManager
    {
        private readonly Container container;
        private readonly Dictionary<Type, Form> OpenedForms;

        public FormManager(Container container)
        {
            this.container = container;
            this.OpenedForms = new Dictionary<Type, Form>();
        }

        public void ShowForm<TForm>() where TForm : Form
        {
            Form form;
            if (this.OpenedForms.ContainsKey(typeof(TForm)))
            {
                form = this.OpenedForms[typeof(TForm)];
            }
            else
            {
                form = this.getForm<TForm>();
                this.OpenedForms.Add(form.GetType(), form);
                form.Closed += (s, e) => this.OpenedForms.Remove(form.GetType());
            }

            form.Show();
        }

        public void ShowForm<TForm>(int id) where TForm : Form
        {
            Form form;
            if (this.OpenedForms.ContainsKey(typeof(TForm)))
            {
                form = this.OpenedForms[typeof(TForm)];
            }
            else
            {
                form = this.getForm<TForm>();
                this.OpenedForms.Add(form.GetType(), form);
                form.Closed += (s, e) => this.OpenedForms.Remove(form.GetType());
            }
            form.Show();
        }

        public TForm GetForm<TForm>() where TForm: Form
        {
            if(this.OpenedForms.ContainsKey(typeof(TForm)))
                return this.OpenedForms[typeof(TForm)] as TForm;

            else return getForm<TForm>() as TForm;
        } 

        private Form getForm<TForm>() where TForm : Form
        {
            return this.container.GetInstance<TForm>();
        }
    }
}
