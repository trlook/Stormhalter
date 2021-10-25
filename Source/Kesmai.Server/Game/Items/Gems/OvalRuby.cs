﻿using System;
using System.Collections.Generic;
using System.IO;
using Kesmai.Server.Network;

namespace Kesmai.Server.Items
{
	public partial class OvalRuby : Gem
	{
		/// <inheritdoc />
		public override int Weight => 5;

		/// <summary>
		/// Initializes a new instance of the <see cref="OvalRuby"/> class.
		/// </summary>
		[WorldForge]
		public OvalRuby(uint basePrice) : base(63, basePrice)
		{
		}

		/// <inheritdoc />
		public override void GetDescription(List<LocalizationEntry> entries)
		{
			entries.Add(new LocalizationEntry(6200000, 6200119)); /* [You are looking at] [an oval shaped ruby.] */
		}
	}
}