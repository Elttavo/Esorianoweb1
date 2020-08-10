/**
* Simple Horizontal Scroll v0.1
* By: me@daantje.nl
* last update: Sun Dec 24 00:13:19 CET 2006
*
*	Documentation: Copy & paste
*	License: LGPL
*	Support: some.
*/

var scrllTmr;
window.onload = function(){
	//set style
	document.getElementById('scroll').style.overflow = 'hidden';
	document.getElementById('scrollme').style.float = 'left';
	document.getElementById('scrollme').style.position = 'relative';

	//get canvas
	cw = parseInt(document.getElementById('scroll').offsetWidth);
	w = parseInt(document.getElementById('scrollme').offsetWidth);
	
	//start scroll
	lft = cw + w;
	document.getElementById('scrollme').style.left = lft + "px";
	scrollStep(cw,w,lft);
}
function scrollStep(cw,w,lft){
	//calc and do step
	if(lft == w * -1)
		lft = cw + w;
	document.getElementById('scrollme').style.left = lft + "px";
	
	//wait and do next...
	if(scrllTmr)
		clearTimeout(scrllTmr);
	scrllTmr = setTimeout('scrollStep(cw,w,' + (lft - 1) + ')',15);
}
