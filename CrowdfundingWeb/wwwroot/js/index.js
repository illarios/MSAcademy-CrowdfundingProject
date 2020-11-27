$(document).ready(function() {
    $('section').click(function() {
        var $this = $(this);
        if ($this.hasClass("show-desc")) {
            $this.find('div.cover').css({top: "0"});
            $this.find('div.desc').css({top: "100%"});
            $this.find('[class*="entypo-"]').removeClass('spin-out').addClass('spin-in');
            $this.find('.cover h5').addClass('scoot-in');
            $this.removeClass("show-desc");
        }
        else {
            $this.find('div.cover').css({top: "-100%"});
            $this.find('div.desc').css({top: "0"});
            $this.find('[class*="entypo-"]').removeClass('spin-in').addClass('spin-out');
            $this.find('.cover h5').removeClass('scoot-in').addClass('scoot-out');
            $this.addClass("show-desc");
        }
    });
});

