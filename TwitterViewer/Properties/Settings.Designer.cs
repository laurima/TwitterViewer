﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TwitterViewer.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("hDfxDffMyp3xmnAFcCMM9IzuH")]
        public string ConsumerKey {
            get {
                return ((string)(this["ConsumerKey"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ic6M72jx7WcDtICakJHmXkehilHtxJ1sWgKC84dkujlPG9n8Fv")]
        public string ConsumerSecret {
            get {
                return ((string)(this["ConsumerSecret"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2216257297-3Nzd3W3Qyl4lCqJU4GzhKsNxgjeVmVZZmmstMoo")]
        public string AccessToken {
            get {
                return ((string)(this["AccessToken"]));
            }
            set {
                this["AccessToken"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("ie903ODJe2mApqI9TLt73mnGoymv65FSZGGwm9tUJ5zJd")]
        public string AccessTokenSecret {
            get {
                return ((string)(this["AccessTokenSecret"]));
            }
            set {
                this["AccessTokenSecret"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2216257297")]
        public string UserID {
            get {
                return ((string)(this["UserID"]));
            }
            set {
                this["UserID"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Z:\\GitHub\\TwitterViewer\\Followedusers.json")]
        public string FollowedUsersJSON {
            get {
                return ((string)(this["FollowedUsersJSON"]));
            }
            set {
                this["FollowedUsersJSON"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Z:\\GitHub\\TwitterViewer\\Categories.json")]
        public string CategoriesJSON {
            get {
                return ((string)(this["CategoriesJSON"]));
            }
            set {
                this["CategoriesJSON"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Z:\\GitHub\\TwitterViewer\\Categories.xml")]
        public string CategoriesXML {
            get {
                return ((string)(this["CategoriesXML"]));
            }
            set {
                this["CategoriesXML"] = value;
            }
        }
    }
}
