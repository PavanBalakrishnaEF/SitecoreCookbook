//
var config={
	WebsiteRoot:'C:/inetpub/wwwroot/Sitecore91.local/'
	
}

var gulp=require('gulp');

gulp.task('default',function(){
	
})


gulp.task('publish-views',function(){
	gulp.src('SitecoreCookbook/Views/**/*.cshtml')
	.pipe(gulp.dest(config.WebsiteRoot+'/Views'));
		
})


gulp.task('publish-config',function(){
	gulp.src('SitecoreCookbook/App_config/Include/**/*.config')
	.pipe(gulp.dest(config.WebsiteRoot+'/App_config/Include/'));
})
