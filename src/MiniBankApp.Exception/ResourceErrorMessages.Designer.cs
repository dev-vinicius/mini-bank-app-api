﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiniBankApp.Exception {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "17.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ResourceErrorMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ResourceErrorMessages() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MiniBankApp.Exception.ResourceErrorMessages", typeof(ResourceErrorMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O Valor não pode ser menor que zero.
        /// </summary>
        public static string ACCOUNT_BALANCE_INVALID {
            get {
                return ResourceManager.GetString("ACCOUNT_BALANCE_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O Nome é obrigatório e deve conter no mínimo 3 caracteres.
        /// </summary>
        public static string ACCOUNT_NAME_INVALID {
            get {
                return ResourceManager.GetString("ACCOUNT_NAME_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Conta solicitada não foi encontrada.
        /// </summary>
        public static string ACCOUNT_NOT_FOUND {
            get {
                return ResourceManager.GetString("ACCOUNT_NOT_FOUND", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Você não possui saldo suficiente para realizar esta transação.
        /// </summary>
        public static string TRANSACTION_INSUFICIENT_BALANCE_FOR_DEBIT {
            get {
                return ResourceManager.GetString("TRANSACTION_INSUFICIENT_BALANCE_FOR_DEBIT", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A Conta informada é inválida.
        /// </summary>
        public static string TRANSACTION_ORIGIN_ACCOUNT_INVALID {
            get {
                return ResourceManager.GetString("TRANSACTION_ORIGIN_ACCOUNT_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O Valor da transação deve ser maior que zero.
        /// </summary>
        public static string TRANSACTION_VALUE_INVALID {
            get {
                return ResourceManager.GetString("TRANSACTION_VALUE_INVALID", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Erro desconhecido.
        /// </summary>
        public static string UNKNOW_ERROR {
            get {
                return ResourceManager.GetString("UNKNOW_ERROR", resourceCulture);
            }
        }
    }
}