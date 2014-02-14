using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PaintDotNet.Effects;

namespace SelectionInnerContour
{
	/// <summary>
	/// Since the visual studio designer can not handle form base classes
	/// with generic parameters as direct base classes, we define this class
	/// inbetween.
	/// </summary>
	class SicConfigDialog_ : EffectConfigDialog<SicEffect, SicToken>
	{
		protected override SicToken CreateInitialToken()
		{
			return null;
		}

		protected override void InitDialogFromToken(SicToken effectTokenCopy)
		{}

		protected override void LoadIntoTokenFromDialog(SicToken writeValuesHere)
		{}
	}
}
