var infoList = [];
var placeList = [];
var placeInfoList = [];
var markersList = [];

function addPlace(element, array) {
    placeList.push(element);
}
function addInfo(element, array) {
    infoList.push(element);
}
function generateEndObjects() {
    const equijoin = (xs, ys, primary, foreign, sel) => {
        const ix = xs.reduce((ix, row) => ix.set(row[primary], row), new Map);
        return ys.map(row => sel(ix.get(row[foreign]), row));
    };
    placeInfoList = equijoin(placeList, infoList, "id", "placeId", ({ latitude, longitude, name, category },
    { numberOfPeople, temperature, humidity }) => ({ latitude, longitude, name, category, numberOfPeople, temperature, humidity }));

    for (i = 0; i < placeInfoList.length; i++) {
        if (placeInfoList[i].numberOfPeople <= 100)
            var img = "img/small.png";
        else if (placeInfoList[i].numberOfPeople > 100 && placeInfoList[i].numberOfPeople <= 200)
            var img = "img/med.png";
        else
            var img = "img/big.png";

        var newMarker = {
            coords: { lat: placeInfoList[i].latitude, lng: placeInfoList[i].longitude },
            iconImage: img,
            content: "<h5>" + placeInfoList[i].name + "</h5>"
                + "<p>Liczba ludzi: " + placeInfoList[i].numberOfPeople + "</p>"
                + "<p>Temperatura: " + placeInfoList[i].temperature + "</p>"
                + "<p>Wilgotność: " + placeInfoList[i].humidity + "</p>"
        }
        markersList.push(newMarker);
    }
}
$.ajax({
    type: 'GET',
    url: "https://localhost:44379/api/map/GetPlaces",
    dataType: 'json',
    success: function (data) {
    data.forEach(addPlace);
    }
});

//map
function initMap() {
    var options = {
        zoom: 13,
        center: { lat: 50.0412, lng: 21.9991 }
    }
    var map = new google.maps.Map(document.getElementById('map'), options);
    var markers = [];

    addPointsToMap();
    setInterval(addPointsToMap, 5100);

    $(document).ajaxComplete(function () {
        generateEndObjects();

        for (var i = 0; i < markers.length; i++) {
            markers[i].setMap(null);
        }
        for (var i = 0; i < markersList.length; i++) {
            addMarker(markersList[i]);
        }
    });

    function addPointsToMap() {
        $.ajax({
            type: 'GET',
            url: "https://localhost:44379/api/map",
            dataType: 'json',
            success: function (data) {
                data.forEach(addInfo);
            }
    });

    infoList = [];
    placeInfoList = [];
    markersList = [];
    }

    function addMarker(props) {
        var marker = new google.maps.Marker({
            position: props.coords,
            map: map,
    });

    if (props.iconImage) {
        marker.setIcon(props.iconImage);
    }

    if (props.content) {
        var infoWindow = new google.maps.InfoWindow({
            content: props.content
        });

        marker.addListener('click', function () {
            infoWindow.open(map, marker);
        });
    }
    markers.push(marker);
    }

    function addUserMarker() {
        navigator.geolocation.getCurrentPosition(function (location) {
            var marker = new google.maps.Marker({
                position:{lat:location.coords.latitude,lng:location.coords.longitude},
                icon:'img/you.png',
                map:map                    
                });

        });
    }

    if ('geolocation' in navigator) {
        addUserMarker();
    } else {
        console.log('Geolocation API not supported.');
    }
}