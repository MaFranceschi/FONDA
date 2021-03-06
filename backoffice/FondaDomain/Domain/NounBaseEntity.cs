﻿using System;
using System.Runtime.Serialization;

namespace com.ds201625.fonda.Domain
{
    /// <summary>
    /// Entidad con nombre (Sustantivo)
    /// </summary>
    [DataContract]
    public class NounBaseEntity : BaseEntity
	{

		/// <summary>
		/// El nombre de la entidad
		/// </summary>
		private string _name;

		/// <summary>
		/// Construntor
		/// </summary>
		public NounBaseEntity () : base () { }

		/// <summary>
		/// Obtiene y asigna el nombre de la entidad
		/// </summary>
		/// <value>El nombre</value>
		[DataMember]
		public virtual string Name
		{
			get { return _name; }
			set { _name = value; }
		}

	}
}

