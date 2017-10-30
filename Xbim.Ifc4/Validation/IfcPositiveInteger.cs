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
namespace Xbim.Ifc4.MeasureResource
{
	public partial struct IfcPositiveInteger : IExpressValidatable
	{
		public enum IfcPositiveIntegerClause
		{
			WR1,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcPositiveIntegerClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcPositiveIntegerClause.WR1:
						retVal = this > 0;
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger(Type.GetType("Xbim.Ifc4.MeasureResource.IfcPositiveInteger"));
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcPositiveInteger.{0}'.", clause), ex);
			}
			return retVal;
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcPositiveIntegerClause.WR1))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcPositiveInteger.WR1", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
