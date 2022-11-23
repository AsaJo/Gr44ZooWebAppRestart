// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function getLastAnimal(actionUrl) {
    $.get(actionUrl, function (response) {
        console.log("Response", response);
        document.getElementById("result").innerHTML = response;
    });
}

function getAnimalList(actionUrl) {
    $.get(actionUrl, function (response) {
        console.log("Response:", response);
        document.getElementById("result").innerHTML = response;
    });
}
function getLastAnimalJSON(actionUrl) {
    $.get(actionUrl, function (response) {
        console.log("JSON Response:", response);
        document.getElementById("result").innerHTML = response;
    });
}
function postWithAjax(actionUrl, idInput) {
    let inputElement = $("#" + idInput)
    let data = {
        [inputElement.attr("name")]:inputElement.val()
    }
    console.log("inputElement:", inputElement);
    console.log("data:", data);

    $.post(actionUrl, data, function (response) {
        console.log("Response", response);
        document.getElementById("result").innerHTML = response;
    });
}

function postSpeciesWithAjax(actionUrl, inputSpecies) {
    let inputElement = $("#" + inputSpecies);
    let data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputElement:", inputElement);
    console.log("data:", data);
    // post : url , data to post , what to do when we get the response back
    $.post(actionUrl+"?species="+ data.species, function (response) {
        console.log("Ajax response:", response);
        document.getElementById("result").innerHTML = response;
    });
}

function postWithAjaxDelete(actionUrl, idInput) {
    let inputElement = $("#" + idInput)
    let data = {
        [inputElement.attr("name")]: inputElement.val()
    }
    console.log("inputElement:", inputElement);
    console.log("data:", data);

    $.post(actionUrl, data, function (response) {
        console.log("Response", response);
        document.getElementById("result").innerHTML = response;
    });
}