using System;
using System.Collections.Generic;
using System.IO;

using Kesmai.Server.Game;
using Kesmai.Server.Network;
using Kesmai.Server.Spells;

namespace Kesmai.Server.Items
{
	public partial class BlindFearProtectionBracelet : Bracelet, ITreasure
	{
		/// <inheritdoc />
		public override uint BasePrice => 3500;

		/// <inheritdoc />
		public override int Weight => 4;

		/// <summary>
		/// Initializes a new instance of the <see cref="BlindFearProtectionBracelet"/> class.
		/// </summary>
		public BlindFearProtectionBracelet() : base(22)
		{
		}

		/// <inheritdoc />
		public override void GetDescription(List<LocalizationEntry> entries)
		{
			entries.Add(new LocalizationEntry(6200000, 6200042)); /* [You are looking at] [a wavy silver bracelet set with aquamarines.] */

			if (Identified)
				entries.Add(new LocalizationEntry(6250032)); /* The bracelet contains the spell of Protection from Blind and Fear. */
		}

		protected override bool OnEquip(MobileEntity entity)
		{
			if (!base.OnEquip(entity))
				return false;

			if (!entity.GetStatus(typeof(BlindFearProtectionStatus), out var resistance))
			{
				resistance = new BlindFearProtectionStatus(entity)
				{
					Inscription = new SpellInscription() { SpellId = 41 }
				};
				resistance.AddSource(new ItemSource(this));
				
				entity.AddStatus(resistance);
			}
			else
			{
				resistance.AddSource(new ItemSource(this));
			}

			return true;
		}

		protected override bool OnUnequip(MobileEntity entity)
		{
			if (!base.OnUnequip(entity))
				return false;
			
			if (entity.GetStatus(typeof(BlindFearProtectionStatus), out var resistance))
				resistance.RemoveSourceFor(this);

			return true;
		}
	}
}