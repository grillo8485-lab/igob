
var markersArray = [];

function initAutocomplete() {
    let mapa = document.getElementById('map');
    if (mapa != null) {
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
            var res = coordenadas.replace("(", "").replace(")", "");
            addMarker(event.latLng, map);
            $("#Lugar").val(res);
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
            let map = new google.maps.Map(document.getElementById(document.getElementsByClassName('maps')[i].getAttribute('id')), mapOptions);

            var beachMarker = new google.maps.Marker({
                position: { lat: parseFloat(pos[0]), lng: parseFloat(pos[1]) },
                map: map
            });
        }
    }
}
function mapsPropuestaTenica() {

    var maps = $(".maps").length;

    let ids = [];
    let coord = [];

    var map = "";
    var location = "";
    for (let i = 1; i <= maps; i++) {
        map = "map-" + i;
        location = $("#hidden-" + i).val()
        //ids.push(document.getElementsByClassName('maps')[i].getAttribute('id'));
        //coord.push(document.getElementsByClassName('inpt')[i].getAttribute('value'));
        placeMarkerPorMapa(location, map)
    }

}
function mapsPropuestaTenicaValida() {

    var maps = $(".mapValida").length;

    let ids = [];
    let coord = [];

    var map = "";
    var location = "";
    for (let i = 1; i <= maps; i++) {
        map = "mapValida-" + i;
        location = $("#hiddenValida-" + i).val()
        placeMarkerPorMapa(location, map)
    }

}
function placeMarker(location) {
    if (location != null) {
        var pos = location.split(",");
        var myCenter = new google.maps.LatLng(parseFloat(pos[0]), parseFloat(pos[1]));
        var mapProp = {
            center: myCenter, zoom: 14, scrollwheel: false, draggable: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            zoomControl: true,
            mapTypeControl: false,
            scaleControl: true,
            streetViewControl: false,
            rotateControl: false,
            fullscreenControl: false
        };
        var map = new google.maps.Map(document.getElementById("map"), mapProp);
        var marker = new google.maps.Marker({
            position: { lat: parseFloat(pos[0]), lng: parseFloat(pos[1]) },
            map: map,
            draggable: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        google.maps.event.addListener(marker, 'dragend', function (event) {
            $("#Lugar").val(this.getPosition().lat() + "," + this.getPosition().lng());
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
        $("#Lugar").val(this.getPosition().lat() + "," + this.getPosition().lng());
    });
}


function clearOverlays() {
    for (var i = 0; i < markersArray.length; i++) {
        markersArray[i].setMap(null);
    }
}

function placeMarkerPorMapa(location,IdMpapa) {
    if (location != null) {
        var pos = location.split(",");
        var myCenter = new google.maps.LatLng(parseFloat(pos[0]), parseFloat(pos[1]));
        var mapProp = {
            center: myCenter, zoom: 14, scrollwheel: false, draggable: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP,
            zoomControl: true,
            mapTypeControl: false,
            scaleControl: true,
            streetViewControl: false,
            rotateControl: false,
            fullscreenControl: false
        };
        var map = new google.maps.Map(document.getElementById(IdMpapa), mapProp);
        var marker = new google.maps.Marker({
            position: { lat: parseFloat(pos[0]), lng: parseFloat(pos[1]) },
            map: map,
            draggable: true,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        });

        google.maps.event.addListener(marker, 'dragend', function (event) {
            $("#Lugar").val(this.getPosition().lat() + "," + this.getPosition().lng());
        });
    }
}