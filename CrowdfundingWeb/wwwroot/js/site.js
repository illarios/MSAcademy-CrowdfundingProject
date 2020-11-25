// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//======================B A C K E R S===========================
$('#create-profile-backer').on('click', () => {
    addBacker();
});

function addBacker()
{
    let actionUrl = "/api/backer"    //<------------
    let $successAlert = $('#create-profile-success1');

    let formData = {
        "Username": $("#username").val(),
        "Email": $("#email").val(),
        "Wallet": $("#wallet").val(),
    }
    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "POST",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#CreateProfileForm').hide();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function updateBacker() {
    actionUrl = "/api/Backer/update" + id    //<------------
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "Username": $("#Username").val(),
        "Email": $("#Email").val(),
        "Wallet": $("#Wallet").val(),
    }

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {
            alert(JSON.stringify(data))
            window.open("/home/Backer", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function updateBacker() {
    id = $("#Id").val()

    actionUrl = "/api/Backer/delete/" + id    //<----------
    actiontype = "DELETE"
    actionDataType = "json"

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

//====================== C R E A T O R S========================
// by ID -> Selector # $('#create-profile')
// by class name -> Selector . $('.js-create-profile')
// by attribute name -> selector [] $('[type="submit"]')
$('#create-profile').on('click', () => {
    addCreator();
});

function addCreator() {
    let actionUrl = '/api/creator';
    let $successAlert = $('#create-profile-success');
    
    let formData = {
        username: $('#username').val(),
        email: $('#email').val(),
        bio: $('#bio').val()
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "POST",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#CreateProfileForm').hide();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function getCreator() {
    let actionUrl = '/home/DisplayCreators';
    //let $successAlert = $('#create-profile-success');

    let formData = {
        username: $('#username').val(),
        email: $('#email').val(),
        bio: $('#bio').val()
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "GET",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#CreateProfileForm').hide();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

$('#edit-profile').on('click', () => {
    updateCreator();
});

function updateCreator() {
    let id = $('#Id').val()
    let actionUrl = '/api/creator/update/'+ id
    let $successAlert = $('#edit-profile-success');

    let formData = {       
        email: $('#email').val(),
        bio: $('#bio').val()
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "PUT",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#EditProfileForm').hide();
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function deleteCreator() {
    id = $("#Id").val()

    actionUrl = "/api/Creator/delete/" + id    //<----------
    actiontype = "DELETE"
    actionDataType = "json"

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

//====================== P R O J E C T S =======================

function addProject() {
    actionUrl = "/api/project/create"    //<------------
    actiontype = "POST"
    actionDataType = "json"

    sendData = {
        "title": $("#Title").val(),
        "description": $("#Description").val(),
        "category": $("#Category").val(),
        "goal": $("#Goal").val(),
        "endDate": $("#EndDate").val()
    }

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {
            alert(JSON.stringify(data))
            window.open("/home/customers", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}




function updateProject() {
    id = $("#Id").val()
    actionUrl = "/api/project/update/"+id    //<----------
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "title": $("#Title").val(),
        "description": $("#Description").val(),
        "category": $("#Category").val(),
        "goal": $("#Goal").val(),
        "endDate": $("#EndDate").val()
    }

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {
            alert(JSON.stringify(data))
            window.open("/home/customers", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function updateProject() {
    id = $("#Id").val()

    actionUrl = "/api/project/delete/" + id    //<----------
    actiontype = "DELETE"
    actionDataType = "json"

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

//====================== B U N D L E S =======================

function addBundle() {
    id = $("#Id").val()

    actionUrl = "/api/project/"+ id +"/bundle/add"    //<------------
    actiontype = "POST"
    actionDataType = "json"

    sendData = {
        "description": $("#Description").val(),
        "prize": $("#Prize").val(),
        "goal": $("#Goal").val(),
    }

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {
            alert(JSON.stringify(data))
            window.open("/home/customers", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function updateBundle() {
    id = $("#Id").val()

    actionUrl = "/api/project/" + id + "/bundle/update"    //<------------
    actiontype = "PUT"
    actionDataType = "json"

    sendData = {
        "description": $("#Description").val(),
        "prize": $("#Prize").val(),
        "goal": $("#Goal").val(),
    }

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        data: JSON.stringify(sendData),
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {
            alert(JSON.stringify(data))
            window.open("/home/customers", "_self")
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

function deleteBundle() {
    id = $("#Id").val()

    actionUrl = "/api/project/" + id + "/bundle/delete"    //<------------
    actiontype = "DELETE"
    actionDataType = "json"

    $.ajax({
        url: actionUrl,
        dataType: actionDataType,
        type: actiontype,
        contentType: 'application/json',
        processData: false,

        success: function (data, textStatus, jQxhr) {

            alert(JSON.stringify(data))
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

// Login Event

$('#creator-login').on('click', () => {
    CheckCreatorLogin();
});

async function CheckCreatorLogin() {
    let userEmail = $('#user-email').val();
    let password = $('#user-password').val();
    
    let loginOptions = {
        email: userEmail,
        password: password
    };

    $.ajax({
        url: '/home/functionl',
        contentType: 'application/json',
        type: 'POST',
        data: JSON.stringify(loginOptions),
        success: function (data) {
            localStorage.setItem('userId', data.userId);
            window.open("/home/DisplayCreators", "_self")
        },
        error: function () {
            alert('Login denied');
        }
    });
}

$('#backer-login').on('click', () => {
    CheckBackerLogin();
});

async function CheckBackerLogin() {
    let userEmail = $('#user-email').val();
    let password = $('#user-password').val();

    let loginOptions = {
        email: userEmail,
        password: password
    };

    $.ajax({
        url: '/home/functionlbk',
        contentType: 'application/json',
        type: 'POST',
        data: JSON.stringify(loginOptions),
        success: function (data) {
            localStorage.setItem('userId', data.userId);
            window.open("/home/DisplayCreators", "_self")
        },
        error: function () {
            alert('Login denied');
        }
    });
}

function getUserId() {
    return localStorage.getItem('userId');
}

// Sign-up button-Creator & backer

$('#creator-sign-up').on('click', function () {
    window.open("/home/CreateProfile", "_self");
});

$('#backer-sign-up').on('click', function () {
    window.open("/home/CreateProfileBacker", "_self");
});
