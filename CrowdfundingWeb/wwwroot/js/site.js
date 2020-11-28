﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//======================HOME NAVIGATION===========================
$('#b1').on('click', () => {
    if(getBackerId())
    {
        window.location.href = "/backermenu/bdashboard";
    }
    else
    {
        window.location.href = "/home/loginbacker"; 
    }
});

$('#b2').on('click', () => {
    if(getCreatorId())
    {
        window.location.href = "/creatormenu/cdashboard";
    }
    else
    {
        window.location.href = "/home/logincreator";
    }
});


//======================B A C K E R S===========================
$('#create-profile-backer').on('click', () => {
    addBacker();
});

function addBacker()
{
    let actionUrl = '/api/backer'   //<------------
    let $successAlert = $('#create-profile-success1');

    let formData = {
        "Username": $("#username").val(),
        "Email": $("#email").val(),
        "Wallet": parseInt($("#wallet").val()), 
    }
    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "POST",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#CreateBackerProfileForm').hide();
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
    let id = getUserId();
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

$('#create-project').on('click', () => {
    addProject();
});

function addProject() {
    let actionUrl = '/api/project/create';
    let $successAlert = $('#create-project-success');
    let id = getUserId();

    let formData = {
        id: parseInt(id),
        title: $('#title').val(),
        description: $('#description').val(),
        goal: parseInt($('#goal').val()),
        endDate: $('#endDate').val().toString(),
        category: $(".categoryOptions:checked").val()
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: 'POST',
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#CreateProjectForm').hide();
            $('#create-project-success').show();
            $('#CreateBundlesForm').show();
            localStorage.setItem('projectId', data);
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
$('#project-link').on('click', () => {
    ShowProject();
});

function ShowProject() {
    //let $successAlert = $('#create-bundle-success');
    let projectId = getProjectId();

    window.location.href = window.location.origin + '/backermenu' + '/projectview?id=' + profileUserId;
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

function deleteProject() {
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

$('#btn-search').on('click', function () {
    let title = $('#txt-search-title').val();
    let description = $('#txt-search-description').val();    

    let requestData = {
        title: title,
        description: description
    }       

    $.ajax({
        url: '/BackerMenu/GetProjects',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(requestData),
        success: function (projects)
        {
            $('#projects-list-card').html('');

            for (let i = 0; i < projects.length; i++) {
                $('#projects-list-card').append(`
                    <div class="card border-left-primary shadow  py-2" style="background-color:#e9f1f7">
                    <div class="card-body">

                        <div class="text-xs font-weight-bold text text-uppercase mb-1" style="color:#2c4a58">
                            <a class="nav-link active text-light" asp-controller="BackerMenu" asp-action="ProjectView" asp-route-id="@project.Id">${projects[i].title}</a> <span class="badge badge-success">New</span>
                        </div>  <!-- Make it pop up only for new ones -->
                            <!-- Progress -->
                            <div class="h5 mb-0 mr-3 font-weight-bold text" style="color:#2c4a58">Goal Completion:${projects[i].progress} %</div>

                        <div class="progress">
                            <div id="one" class="progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="${projects[i].progress}" aria-valuemin="0" aria-valuemax="100" style="width:${projects[i].progress};background-color:#2c4a58;">
                            </div>
                        </div>
                      

                        </div>
                </div>
                `);

               
            }
        }
    });
});

//====================== B U N D L E S =======================
$('#create-bundles').on('click', () => {
    addBundle();
});

function addBundle() {
    id = $("#Id").val()
    let actionUrl = '/api/project/bundles';
    let $successAlert = $('#create-bundle-success');
    let projectId = getProjectId();

    let formData = {
        projectId: projectId,
        bundles: [{
            prize: $('#prize1').val(),
            description: $('#bundledescription1').val()
        },
        {
            prize: $('#prize2').val(),
            description: $('#bundledescription2').val()
        },
        {
            prize: $('#prize3').val(),
            description: $('#bundledescription3').val()
        }
        ]
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        processData: false,
        type: 'POST',
        success: function (bundles) {
            $successAlert.fadeIn(500);
            $('#CreateBundlesForm').hide();
            $('#create-bundle-success').show();
            localStorage.removeItem('projectId');  //**************************************
            window.open("/CreatorMenu/CDashboard", "_self")
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
            localStorage.setItem('creatorId', data.userId);
            window.open("/CreatorMenu/CDashboard", "_self")
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
            localStorage.setItem('backerId', data.userId);
            window.open("/BackerMenu/BDashboard", "_self")
        },
        error: function () {
            alert('Login denied');
        }
    });
}

function getUserId() {
    return localStorage.getItem('userId');
}

function getBackerId() {
    return localStorage.getItem('backerId');
}

function getCreatorId() {
    return localStorage.getItem('creatorId');
}

function getProjectId() {
    return localStorage.getItem('projectId');
}

// Sign-up button-Creator & backer

$('#creator-sign-up').on('click', function () {
    window.open("/home/CreateProfile", "_self");
});

$('#backer-sign-up').on('click', function () {
    window.open("/home/CreateProfileBacker", "_self");
});

$('#my-profile').on('click', () => {
    GetEditProfile();
});

function GetEditProfile() {
    var profileUserId = localStorage.getItem('userId');  
    let params = { UserId: profileUserId }; 
    window.location.href = window.location.origin + '/creatormenu' + '/editprofilenew?id=' + profileUserId;
    
}

if(getUserId() || getBackerId() || getCreatorId())
{
    $('#logout-btn').show();
}

$('#logout-btn').on('click', function () {
    localStorage.removeItem('userId');
    localStorage.removeItem('backerId');
    localStorage.removeItem('creatorId');
    $('#logout-btn').hide();
    window.location.href = "/home";
});

