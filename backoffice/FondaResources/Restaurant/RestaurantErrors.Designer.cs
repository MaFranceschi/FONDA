﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace com.ds201625.fonda.Resources.FondaResources.Restaurant {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class RestaurantErrors {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal RestaurantErrors() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("com.ds201625.fonda.Resources.FondaResources.Restaurant.RestaurantErrors", typeof(RestaurantErrors).Assembly);
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
        ///   Looks up a localized string similar to Comando para generar un objeto restaurante.
        /// </summary>
        public static string ClassNameGenerateRestaurant {
            get {
                return ResourceManager.GetString("ClassNameGenerateRestaurant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to CommandGetTables.
        /// </summary>
        public static string ClassNameGetReservations {
            get {
                return ResourceManager.GetString("ClassNameGetReservations", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al generar el objeto restaurante (Command).
        /// </summary>
        public static string CommandExceptionGenerateRestaurant {
            get {
                return ResourceManager.GetString("CommandExceptionGenerateRestaurant", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Execute.
        /// </summary>
        public static string CommandMethod {
            get {
                return ResourceManager.GetString("CommandMethod", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error obteniendo las mesas de un Restaurante.
        /// </summary>
        public static string ErrorMessageGetTables {
            get {
                return ResourceManager.GetString("ErrorMessageGetTables", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al generar el objeto restaurante (DAO).
        /// </summary>
        public static string GenerateRestaurantFondaDAOException {
            get {
                return ResourceManager.GetString("GenerateRestaurantFondaDAOException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error tipo de parametro inválido.
        /// </summary>
        public static string InvalidTypeParameterException {
            get {
                return ResourceManager.GetString("InvalidTypeParameterException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error al modificar el objeto restaurante (DAO).
        /// </summary>
        public static string ModifyRestaurantFondaDAOException {
            get {
                return ResourceManager.GetString("ModifyRestaurantFondaDAOException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parámetro fuera de rango.
        /// </summary>
        public static string ParameterIndexOutRangeException {
            get {
                return ResourceManager.GetString("ParameterIndexOutRangeException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Error parámetro requerido no encontrado.
        /// </summary>
        public static string RequieredParameterNotFoundException {
            get {
                return ResourceManager.GetString("RequieredParameterNotFoundException", resourceCulture);
            }
        }
    }
}
