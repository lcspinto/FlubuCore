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

namespace FlubuCore.Tasks.Docker.Trust
{
    public partial class DockerTrustKeyGenerateTask : ExternalProcessTaskBase<int, DockerTrustKeyGenerateTask>
    {
        private string _name;


        public DockerTrustKeyGenerateTask(string name)
        {
            ExecutablePath = "docker";
            WithArguments("trust key generate");
            _name = name;
        }

        protected override string Description { get; set; }

        /// <summary>
        /// Directory to generate key in, defaults to current directory
        /// </summary>
        [ArgKey("--dir")]
        public DockerTrustKeyGenerateTask Dir(string dir)
        {
            WithArgumentsKeyFromAttribute(dir.ToString());
            return this;
        }

        protected override int DoExecute(ITaskContextInternal context)
        {
            WithArguments(_name);

            return base.DoExecute(context);
        }
    }
}