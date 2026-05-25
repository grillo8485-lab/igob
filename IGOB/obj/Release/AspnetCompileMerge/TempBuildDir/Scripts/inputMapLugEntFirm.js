
var markersArray = [];

function initAutocomplete() {
    var map = new google.maps.Map(document.getElementById('map'), {
        center: { lat: 22.2588628, lng: -101.7537043 }, 
        zoom: 4,
        mapTypeId: 'roadmap',
        zoomControl: true,
        mapTypeControl: false,
        scaleControl: true,
        streetViewControl: false,
        rotateControl: false,
        fullscreenControl: false
    });


    // This event listener calls addMarker() when the map is clicked.
    google.maps.event.addListener(map, 'click', function (event) {
        var coordenadas = (event.latLng).toString();
        var res = coordenadas.replace("(", "").replace(")","");
        addMarker(event.latLng, map);
        $("#LocalizacionGoogle").val(res);
    });
    
    var maps = $(".maps").length;

    let ids = [];
    let coord = [];

    // create the maps
    var mapOptions = {
        zoom: 13,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        disableDefaultUI: true
    };

    for (let i = 0; i < maps; i++) {

        ids.push(document.getElementsByClassName('maps')[i].getAttribute('id'));
        coord.push(document.getElementsByClassName('inpt')[i].getAttribute('value'));

        var pos = document.getElementsByClassName('inpt')[i].getAttribute('value').split(",");

        mapOptions.center = new google.maps.LatLng(parseFloat(pos[0]), parseFloat(pos[1]));
       let map =  new google.maps.Map(document.getElementById(document.getElementsByClassName('maps')[i].getAttribute('id')), mapOptions);

        var beachMarker = new google.maps.Marker({
            position: { lat: parseFloat(pos[0]), lng: parseFloat(pos[1]) },
            map: map
        });        
    }
    
}

function placeMarker(location) {
        var map = new google.maps.Map(document.getElementById('map'), {       
            zoom: 5,
            center: { lat: 22.2588628, lng: -101.7537043 },
            mapTypeId: 'roadmap',
            zoomControl: true,
            mapTypeControl: false,
            scaleControl: true,
            streetViewControl: false,
            rotateControl: false,
            fullscreenControl: false
    });

    if (location != null) {
        var pos = location.split(",");
        map.center = new google.maps.LatLng(parseFloat(pos[0]), parseFloat(pos[1]));

        var marker = new google.maps.Marker({
            position: { lat: parseFloat(pos[0]), lng: parseFloat(pos[1]) },
            map: map,
            draggable: true
        });

        google.maps.event.addListener(marker, 'dragend', function (event) {
            $("#LocalizacionGoogle").val(this.getPosition().lat() + "," + this.getPosition().lng());
        });
    }
}


// Adds a marker to the map.
function addMarker(location, map) {

    clearOverlays();

    // Add the marker at the clicked location, and add the next-available label
    // from the array of alphabetical characters.
    var marker = new google.maps.Marker({
        position: location,
        map: map,
        draggable: true
    });

    markersArray.push(marker);


    google.maps.event.addListener(marker, 'dragend', function (event) {
        $("#LocalizacionGoogle").val(this.getPosition().lat() + "," + this.getPosition().lng());
    });
}


function clearOverlays() {
    for (var i = 0; i < markersArray.length; i++) {
        markersArray[i].setMap(null);
    }
}