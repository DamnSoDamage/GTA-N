API.onServerEventTrigger.connect(function(eventName, args) {
    if (eventName == "MUSIC") {
	API.startAudio("e1m1.mp3");
}
   if(eventName == "stop_music"){
    API.stopAudio();
}


});