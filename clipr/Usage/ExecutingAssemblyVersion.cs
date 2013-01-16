﻿using System.Reflection;

namespace clipr.Usage
{
    /// <summary>
    /// Version information pulled from the currently executing assembly.
    /// </summary>
    public class ExecutingAssemblyVersion<T> : IVersion<T> where T : class
    {
        public char? ShortName { get; set; }

        public string LongName { get; set; }

        private readonly string _version;

        /// <summary>
        /// Version information pulled from the currently executing assembly.
        /// </summary>
        public ExecutingAssemblyVersion()
        {
            var assembly = Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly();
            _version = AssemblyName.GetAssemblyName(assembly.Location).Version.ToString();

            ShortName = null;
            LongName = "version";
        }

        public string GetVersion()
        {
            return _version;
        }

        public string PluginName
        {
            get { return "Version"; }
        }

        public void OnParse()
        {
            throw new System.NotImplementedException();
        }


        public ParserConfig<T> Config { get; set; }
    }
}
