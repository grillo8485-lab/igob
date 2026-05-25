function initialize(condition) {

    var maps = $(".maps").length;

    let ids = [];
    let coord = [];

    // create the maps
    var myOptions = {
        zoom: 14,
        center: new google.maps.LatLng(0.0, 0.0),
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    for (let i = 0; i < maps; i++) {

        ids.push(document.getElementsByClassName('map')[i].getAttribute('id'));
        coord.push(document.getElementsByClassName('inpt')[i].getAttribute('id'));       
    }

    console.log(ids);
    console.log(coord);
}