/// <binding ProjectOpened='restore' />
var gulp = require("gulp"),
    bower = require("gulp-bower");

gulp.task("default", function() {
    // place code for your default task here
    return gulp.src("bower_components/jquery/dist/jquery.min.js")
        .pipe(gulp.dest("www/scripts"));
});

gulp.task("restore", function() {
    return bower();
});