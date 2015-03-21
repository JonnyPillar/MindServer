﻿var gulp = require('gulp');
var react = require('gulp-react');
var bower = require('gulp-bower');
var runSequence = require('run-sequence');
var browserify = require('browserify');
var del = require('del');
var source = require('vinyl-source-stream');

/*
*	Default Task
*/

gulp.task('default', function () {
	runSequence(['bower','compile-build-js']);
});

/*
*	Project Folder Tasks
*/

gulp.task('clean-build', function () {
	del('./Scripts/build');
});

gulp.task('clean-release', function () {
	del('./Scripts/release');
});

/*
*	JSX JS Tasks
*/

gulp.task('compile-build-js', function () {
	runSequence(['transform-jsx','browserify']);
});

gulp.task('transform-jsx', ['clean-build'], function () {
	return gulp.src('./Scripts/**/*.jsx')
        .pipe(react())
        .pipe(gulp.dest('./Scripts/build'));
});

gulp.task('browserify', ['clean-release'], function () {
	return browserify( './Scripts/build/app.js')
	        .bundle()
	        .pipe(source('bundle.js'))
	        .pipe(gulp.dest('./Scripts/release'));
});



gulp.task('bower', function () {
    return bower({ layout: "byComponent" });
});

gulp.task('default', ['bower']);