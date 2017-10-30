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
namespace Xbim.Ifc4.BuildingControlsDomain
{
	public partial class IfcFlowInstrumentType : IExpressValidatable
	{
		public enum IfcFlowInstrumentTypeClause
		{
			CorrectPredefinedType,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcFlowInstrumentTypeClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcFlowInstrumentTypeClause.CorrectPredefinedType:
						retVal = (PredefinedType != IfcFlowInstrumentTypeEnum.USERDEFINED) || ((PredefinedType == IfcFlowInstrumentTypeEnum.USERDEFINED) && Functions.EXISTS(this/* as IfcElementType*/.ElementType));
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger(Type.GetType("Xbim.Ifc4.BuildingControlsDomain.IfcFlowInstrumentType"));
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcFlowInstrumentType.{0}' for #{1}.", clause,EntityLabel), ex);
			}
			return retVal;
		}

		public override IEnumerable<ValidationResult> Validate()
		{
			foreach (var value in base.Validate())
			{
				yield return value;
			}
			if (!ValidateClause(IfcFlowInstrumentTypeClause.CorrectPredefinedType))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcFlowInstrumentType.CorrectPredefinedType", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
