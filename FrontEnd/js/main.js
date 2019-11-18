/*Slider Init*/
$(document).ready(function(){
    $('.site-slider .slider-one').not('.slick-intialized').slick({
        autoplay: true,
        speed: 50,
        dots: true,
        prevArrow: ".site-slider .slider-btn .prev",
        nextArrow: ".site-slider .slider-btn .next"
    });
});
const signUpButton = document.getElementById('signUp');
const signInButton = document.getElementById('signIn');
const container = document.getElementById('container');

signUpButton.addEventListener('click', () => {
	container.classList.add("right-panel-active");
});

signInButton.addEventListener('click', () => {
	container.classList.remove("right-panel-active");
});
//
/*document.querySelector('.btn-login')
.addEventListener('click', function(){
    alert('da bam nut dang nhap');
})*/
/*$('.btn-login').click(function(){
    alert('da bam nut dang nhap');
})
$('.button-login').click(function(){
    alert('da bam nut dang nhap');
})
/*document.getElementById('button-login')
.addEventListener('click', function(){
    document.querySelector('.bg-modal')
    .style.display = 'flex'
})
document.querySelector('.close')
.addEventListener('click', function(){
    document.querySelector('.bg-modal').style
    .display = 'none'
})*/
//
