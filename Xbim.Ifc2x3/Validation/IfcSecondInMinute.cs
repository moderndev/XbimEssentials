using System;
using log4net;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using Xbim.Common.Enumerations;
using Xbim.Common.ExpressValidation;
using Xbim.Ifc2x3.MeasureResource;
using Xbim.Ifc2x3.Interfaces;
using Xbim.Ifc2x3.Kernel;
using Xbim.Ifc2x3.ProfileResource;
using Xbim.Ifc2x3.ProfilePropertyResource;
// ReSharper disable once CheckNamespace
// ReSharper disable InconsistentNaming
namespace Xbim.Ifc2x3.DateTimeResource
{
	public partial struct IfcSecondInMinute : IExpressValidatable
	{
		public enum IfcSecondInMinuteClause
		{
			WR1,
		}

		/// <summary>
		/// Tests the express where-clause specified in param 'clause'
		/// </summary>
		/// <param name="clause">The express clause to test</param>
		/// <returns>true if the clause is satisfied.</returns>
		public bool ValidateClause(IfcSecondInMinuteClause clause) {
			var retVal = false;
			try
			{
				switch (clause)
				{
					case IfcSecondInMinuteClause.WR1:
						retVal = ((0 <= this) && (this < 60) );
						break;
				}
			} catch (Exception ex) {
				var Log = LogManager.GetLogger(Type.GetType("Xbim.Ifc2x3.DateTimeResource.IfcSecondInMinute"));
				Log.Error(string.Format("Exception thrown evaluating where-clause 'IfcSecondInMinute.{0}'.", clause), ex);
			}
			return retVal;
		}

		public IEnumerable<ValidationResult> Validate()
		{
			if (!ValidateClause(IfcSecondInMinuteClause.WR1))
				yield return new ValidationResult() { Item = this, IssueSource = "IfcSecondInMinute.WR1", IssueType = ValidationFlags.EntityWhereClauses };
		}
	}
}
