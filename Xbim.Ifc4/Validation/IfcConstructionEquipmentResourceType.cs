using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc4.Interfaces;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc4.ConstructionMgmtDomain
{
	public partial class IfcConstructionEquipmentResourceType : IExpressValidatable
	{
		public enum IfcConstructionEquipmentResourceTypeClause
		{
			CorrectPredefinedType,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcConstructionEquipmentResourceTypeClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcConstructionEquipmentResourceTypeClause.CorrectPredefinedType:
						retVal = (PredefinedType != IfcConstructionEquipmentResourceTypeEnum.USERDEFINED) || ((PredefinedType == IfcConstructionEquipmentResourceTypeEnum.USERDEFINED) && Functions.EXISTS(this/* as IfcTypeResource*/.ResourceType));
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger(Type.GetType("Xbim.Ifc4.ConstructionMgmtDomain.IfcConstructionEquipmentResourceType"));
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcConstructionEquipmentResourceType.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcConstructionEquipmentResourceTypeClause.CorrectPredefinedType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcConstructionEquipmentResourceType.CorrectPredefinedType", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
