using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using IronPython.Hosting;
using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;


namespace PythonFeedback
{
    public partial class Controller : Form
    {

        public Model model { get; private set; }

        private ScriptEngine m_engine = Python.CreateEngine();
        private ScriptScope m_scope = null;


        public Controller(Model model)
            : this()
        {
            this.model = model;
        }

        public Controller()
        {
            InitializeComponent();

            if (this.model == null)
            {
                this.model = new Model();

            }

            m_scope = m_engine.CreateScope();
            m_scope.SetVariable("model", model);
            model.scope = m_scope;

        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //something txtCode
            string code = txtCode.Text.Trim();
            ScriptSource source = m_engine.CreateScriptSourceFromString(code, SourceCodeKind.Statements);
            model.source = source;

            //source.Execute(m_scope);

        }

        private void btnLaunch_Click(object sender, EventArgs e)
        {
            var f = new Fractal(model);
            f.Show();
        }
    }
}
