﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DelOutdatedFiles {
    using System;
    
    
    /// <summary>
    ///   Класс ресурса со строгой типизацией для поиска локализованных строк и т.д.
    /// </summary>
    // Этот класс создан автоматически классом StronglyTypedResourceBuilder
    // с помощью такого средства, как ResGen или Visual Studio.
    // Чтобы добавить или удалить член, измените файл .ResX и снова запустите ResGen
    // с параметром /str или перестройте свой проект VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Strings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Strings() {
        }
        
        /// <summary>
        ///   Возвращает кэшированный экземпляр ResourceManager, использованный этим классом.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("DelOutdatedFiles.Strings", typeof(Strings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Перезаписывает свойство CurrentUICulture текущего потока для всех
        ///   обращений к ресурсу с помощью этого класса ресурса со строгой типизацией.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Configuration file already exists: {0}.
        /// </summary>
        internal static string ConfigurationFile_AlreadyExists {
            get {
                return ResourceManager.GetString("ConfigurationFile_AlreadyExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Configuration file not exists: {0}.
        /// </summary>
        internal static string ConfigurationFile_NotExists {
            get {
                return ResourceManager.GetString("ConfigurationFile_NotExists", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Deleted files in a directory: {0}.
        /// </summary>
        internal static string DeletedFiles {
            get {
                return ResourceManager.GetString("DeletedFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Deleting obsolete archive files.
        /// </summary>
        internal static string HelpDescription_Command_Cleaning {
            get {
                return ResourceManager.GetString("HelpDescription_Command_Cleaning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Create a configuration file &apos;.DelOutdatedFiles&apos; with deletion rules in the specified directory.
        /// </summary>
        internal static string HelpDescription_Command_Init {
            get {
                return ResourceManager.GetString("HelpDescription_Command_Init", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Path to the directory where deletion will be performed according to &quot;.DelOutdatedFiles&quot;. Default in current directory. You can specify multiple folders separated by commas..
        /// </summary>
        internal static string HelpDescription_Option_CleaningDirectoryPath {
            get {
                return ResourceManager.GetString("HelpDescription_Option_CleaningDirectoryPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Path to the directory where the configuration file &apos;.DelOutdatedFiles&apos; will be created. Default in current directory.
        /// </summary>
        internal static string HelpDescription_Option_InitDirectoryPath {
            get {
                return ResourceManager.GetString("HelpDescription_Option_InitDirectoryPath", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Keep a minimum number of files (&gt;=1)..
        /// </summary>
        internal static string HelpDescription_Option_KeepCount {
            get {
                return ResourceManager.GetString("HelpDescription_Option_KeepCount", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Keep files from the last number of days (&gt;=1)..
        /// </summary>
        internal static string HelpDescription_Option_KeepDays {
            get {
                return ResourceManager.GetString("HelpDescription_Option_KeepDays", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на The length of the timestamp of the archives. Masks will be added for present files, where the specified number of characters before the extension will be replaced by *.
        /// </summary>
        internal static string HelpDescription_Option_TimestampLength {
            get {
                return ResourceManager.GetString("HelpDescription_Option_TimestampLength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Invalid directory: {0}.
        /// </summary>
        internal static string InvalidDirectory {
            get {
                return ResourceManager.GetString("InvalidDirectory", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на No outdated files found for: {0}.
        /// </summary>
        internal static string NoOutdatedFiles {
            get {
                return ResourceManager.GetString("NoOutdatedFiles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Check and, if necessary, change the &apos;.DelOutdatedFiles&apos; file in the directory: {0} .
        /// </summary>
        internal static string NotifyOk_InitCommand {
            get {
                return ResourceManager.GetString("NotifyOk_InitCommand", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Error reading configuration file: {0}. {1}.
        /// </summary>
        internal static string СonfigurationFile_ErrorReading {
            get {
                return ResourceManager.GetString("СonfigurationFile_ErrorReading", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Ищет локализованную строку, похожую на Invalid configuration file format: {0}. {1}.
        /// </summary>
        internal static string СonfigurationFile_InvalidFormat {
            get {
                return ResourceManager.GetString("СonfigurationFile_InvalidFormat", resourceCulture);
            }
        }
    }
}
