_5grid.ready(function() {

	// Slider
		var x = $('.box-features');
		if (x.length > 0)
		{
			x.each(function() {
				$(this).slidertron({
					viewerSelector: '.viewer',
					reelSelector: '.viewer .reel',
					slidesSelector: '.viewer .reel article',
					jumpLinksSelector: '.tabs a',
					autoFit: true,
					autoFitAspectRatio: 2.5,
					advanceDelay: 5000,
					advanceWait: 1500,
					speed: 'slow',
					captionLineSelector: '.captions .caption-line-',
					slideCaptionSelector: '.caption-',
					captionLines: 2
				});
			});

			if (_5grid.isMobile)
			{
				_5grid.orientationChange(function() {
					x.trigger('slidertron_reFit');
				});

				_5grid.mobileUINavOpen(function() {
					x.trigger('slidertron_stopAdvance');
				});
			}
		}

	// Drop downs (desktop only)
		if (_5grid.isDesktop)
		{
			$('#nav-top').dropotron({
				offsetY: -5,
				offsetX: -1
			});
		}

});