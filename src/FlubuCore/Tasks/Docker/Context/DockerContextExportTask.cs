//-----------------------------------------------------------------------
// <auto-generated />
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using FlubuCore.Tasks.Attributes;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Docker.Context
{
    public partial class DockerContextExportTask : ExternalProcessTaskBase<int, DockerContextExportTask>
    {
        private string _context;
        private string _file;


        public DockerContextExportTask(string context, string file = null)
        {
            ExecutablePath = "docker";
            WithArguments("context export");
            _context = context;
            _file = file;
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Export as a kubeconfig file
        /// </summary>
        [ArgKey("--kubeconfig")]
        public DockerContextExportTask Kubeconfig()
        {
            WithArgumentsKeyFromAttribute();
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            WithArguments(_context);
            WithArguments(_file);

            return base.DoExecute(context);
        }
    }
}