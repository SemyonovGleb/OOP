﻿namespace lab4_2
{


    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "17.0.3.0")]
    internal sealed partial class App : global::System.Configuration.ApplicationSettingsBase
    {

        private static App defaultInstance = ((App)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new App())));

        public static App Default
        {
            get
            {
                return defaultInstance;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ValueA
        {
            get
            {
                return ((int)(this["ValueA"]));
            }
            set
            {
                this["ValueA"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ValueB
        {
            get
            {
                return ((int)(this["ValueB"]));
            }
            set
            {
                this["ValueB"] = value;
            }
        }

        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0")]
        public int ValueC
        {
            get
            {
                return ((int)(this["ValueC"]));
            }
            set
            {
                this["ValueC"] = value;
            }
        }
    }
}
