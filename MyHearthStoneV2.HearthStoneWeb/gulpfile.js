//准备工作：
//安装node.js
//cmd ==>> 进入项目目录

//1、首页全局安装gulp。
//npm install --global gulp 
//2、其次局部安装gulp。（注：局部安装是安装到你项目的根目录，这是很多教程没有清晰表明）
//npm install gulp --save-dev
//3、安装组件项目目录，通过cd 进入项目的根目录，执行下边的npm安装组件
//npm install  gulp-minify-css gulp-uglify gulp-rename gulp-concat gulp-clean gulp-notify --save-dev
//npm install --save-dev jshint gulp-jshint

//4、生成配置文件
//npm init

//5、执行任务
//gulp

// 引入 gulp及组件
var gulp=require('gulp'),  //gulp基础库
    //minifycss=require('gulp-minify-css'),   //css压缩
    concat=require('gulp-concat'),   //合并文件
    uglify=require('gulp-uglify'),   //js压缩
    rename=require('gulp-rename'),   //文件重命名
    jshint=require('gulp-jshint'),   //js检查
    notify=require('gulp-notify');   //提示

gulp.task('default',function(){
    gulp.start('minifyjs');
});
 
//css处理
gulp.task('minifycss',function(){
    return gulp.src('htdocs/kunpeng/static/css/*.css')      //设置css
        .pipe(concat('order_query.css'))      //合并css文件到"order_query"
        .pipe(gulp.dest('dist/styles'))           //设置输出路径
        .pipe(rename({suffix:'.min'}))         //修改文件名
        .pipe(minifycss())                    //压缩文件
        .pipe(gulp.dest('dist/styles'))            //输出文件目录
        .pipe(notify({message:'css task ok'}));   //提示成功
});

//JS处理
gulp.task('minifyjs', function () {
    return gulp.src(['js/apisign.source.js', 'js/saloon.source.js'])  //选择合并的JS
        .pipe(concat('saloon.js'))   //合并js        
        .pipe(gulp.dest('js/dist'))       //输出        
       .pipe(rename({ suffix: '.min' }))     //重命名        
       .pipe(uglify())                    //压缩        
       .pipe(gulp.dest('js/dist'))            //输出 
       .pipe(notify({message:"js task ok"}));    //提示
});