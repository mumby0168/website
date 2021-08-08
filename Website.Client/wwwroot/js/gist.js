window.loadGist  = (gistUrl)  => {
    console.log(gistUrl);
    const gistScript = document.createElement('script');
    gistScript.type = "text/javascript";
    gistScript.src = gistUrl;
    gistScript.onload = () => {
        const loadedScript = document.getElementById(gistUrl).getElementsByTagName("script")[0];
        console.log(loadedScript.innerHTML);
        
    }
    document.getElementById(gistUrl).appendChild(gistScript);

    var src = gistUrl;
    
    function reqListener(){
        console.log( this.responseText );
    }

    var oReq = new XMLHttpRequest();
    oReq.addEventListener("load", reqListener);
    oReq.open("GET", src);
    oReq.send();
}