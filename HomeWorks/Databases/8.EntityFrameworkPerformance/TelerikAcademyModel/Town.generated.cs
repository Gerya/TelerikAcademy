#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by the ClassGenerator.ttinclude code generation file.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Common;
using System.Collections.Generic;
using Telerik.OpenAccess;
using Telerik.OpenAccess.Metadata;
using Telerik.OpenAccess.Data.Common;
using Telerik.OpenAccess.Metadata.Fluent;
using Telerik.OpenAccess.Metadata.Fluent.Advanced;
using TelerikAcademyModel;

namespace TelerikAcademyModel	
{
	public partial class Town
	{
		private int _townID;
		public virtual int TownID
		{
			get
			{
				return this._townID;
			}
			set
			{
				this._townID = value;
			}
		}
		
		private string _name;
		public virtual string Name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		
		private IList<Address> _addresses = new List<Address>();
		public virtual IList<Address> Addresses
		{
			get
			{
				return this._addresses;
			}
		}
		
	}
}
#pragma warning restore 1591