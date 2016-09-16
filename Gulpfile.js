var gulp = require('gulp'),
    less = require('gulp-less'),
    util = require('gulp-util');
var jshint = require('gulp-jshint');
var source = require('vinyl-source-stream');
var browserify = require('browserify');
var babel = require('gulp-babel');
var browsersync = require('browser-sync').create();

var config = {
    src: './client',
    dest: './wwwroot'
};

var paths = {
    jsIn: config.src + '/js/*',
    jsxIn: config.src + '/jsx/*',
    jsOut: config.src + '/js-out',
    jsRoot: config.src + '/js-out/index.js',
    html: config.src + '/**/*.html',
    less: config.src + '/style/*.less'
};

// builds the project
gulp.task('build', ['react', 'copyJs', 'lint', 'browserify', 'style', 'html']);

// transforms react JSX into JavaScript
gulp.task('react', function () {
	  return gulp.src(paths.jsxIn)
        .pipe(babel({
            plugins: ['transform-react-jsx']
        })).pipe(gulp.dest(paths.jsOut));
});

// copies JavaScript files to our out folder
gulp.task('copyJs', function () {
    gulp.src(paths.jsIn).pipe(gulp.dest(paths.jsOut));
});

// runs the linter on all of our JavaScript
gulp.task('lint', function () {
    return gulp.src(paths.jsOut)
        .pipe(jshint())
        .pipe(jshint.reporter('jshint-stylish'));
});

// bundles in our modules and concatenates our JavaScript
gulp.task('browserify', function() {
    return browserify(paths.jsRoot).bundle()
        .pipe(source('bundle.js'))
        .pipe(gulp.dest(config.dest));
});

// copies over our HTML files
gulp.task('html', function () {
    return gulp.src([paths.html]).pipe(gulp.dest(config.dest));
});

// transforms our LESS files into CSS
gulp.task('style', function () {
    return gulp.src(paths.less)
        .pipe(less())
        .pipe(gulp.dest(config.dest))
        .pipe(browsersync.stream());
});

// starts up a watch and reprocess task for development
gulp.task('watch', function() {
    gulp.watch(paths.jsIn, ['copyJs', 'lint', 'browserify']);
    gulp.watch(paths.jsxIn, ['react', 'lint', 'browserify']);
    gulp.watch(paths.less, ['style']);
    gulp.watch(paths.html, ['html']);
});

// browsersync
gulp.task('browser-sync', function() {
    browsersync.init({
        proxy: "http://localhost:5000/",
        files: config.dest
    });
});

// our default task is to build the app and start the watch
gulp.task('default', ['react', 'copyJs', 'lint', 'browserify', 'style', 'html', 'watch', 'browser-sync']);
gulp.task('run', ['default']);
