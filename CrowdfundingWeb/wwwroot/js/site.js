// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


//======================HOME NAVIGATION===========================
$('#b1').on('click', () => {
    if (getBackerId()) {
        window.location.href = "/backermenu/bdashboard";
    }
    else {
        window.location.href = "/home/loginbacker";
    }
});

$('#b2').on('click', () => {
    if (getCreatorId()) {
        window.location.href = "/creatormenu/cdashboard";
    }
    else {
        window.location.href = "/home/logincreator";
    }
});


//======================B A C K E R S===========================
$('#create-profile-backer').on('click', () => {
    addBacker();
});

function addBacker() {
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
            window.location.href = "/home"
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
$('#edit-profile-backer').on('click', () => {
    updateBacker();
});

function updateBacker() {
    let id = getUserId();
    let actionUrl = '/api/Backer/update/' + id    //<------------   
    let $successAlert = $('#edit-profile-backer-success');

    let formData = {
        "email": $('#email').val(),
        "wallet": parseInt($("#wallet").val()),
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "PUT",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#EditProfileForm-Backer').hide();
            window.location.href = "/backermenu/bdashboard";
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

$('#my-projects').on('click', () => {
    MyProjects();
});

$('#bDashBacker').on('click', () => {
    MyProjects();
});

function MyProjects() {
    var profileUserId = localStorage.getItem('userId');
    window.location.href = window.location.origin + '/backermenu' + '/BDashBoard?id=' + profileUserId;
}

$('#my-profile-backer').on('click', () => {
    GetEditProfileBacker();
});

function GetEditProfileBacker() {
    var profileUserId = localStorage.getItem('userId');
    let params = { UserId: profileUserId };
    window.location.href = window.location.origin + '/backermenu' + '/editprofilenew?id=' + profileUserId;
}

$('#delete-profile-backer').on('click', () => {
    deleteBacker();
});

function deleteBacker() {
    let id = getUserId();
    let actionUrl = "/api/Backer/delete/" + id    //<----------
    let $successAlert = $('#delete-profile-backer-success');
    
    $.ajax({
        url: actionUrl,             
        contentType: 'application/json',
        type:"PUT",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#delete-profile-backer-success').hide();
            localStorage.removeItem('userId');
            localStorage.removeItem('backerId');
            localStorage.removeItem('creatorId');
            $('#logout-btn').hide();    
            window.location.href = "/home"; 
            
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

$('#amount12-btn').on('click', () => {
    supportProject();
});

function checkWallet(amountGiven) {
    
    let backerId = getUserId();
    let actionUrl = '/api/backer/checkwallet';
    let formData = {
        backerId: backerId,
        amountGiven: amountGiven
    };
    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "POST",
        success: function (data) {
            return data;
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert('error !');
        }
    });

}

function supportProject() {
    
    var url = window.location.pathname;
    var id = url.substring(url.lastIndexOf('/') + 1); 
    let backerId = getUserId();
    let actionUrl = '/api/project/support';  
    let $successAlert = $('#support-project-success');

    let bundleid = -1;
    var checkboxes = document.getElementsByName("amountOptions");
    let bool = false;
    for (var i = 0; i != checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            bool = true;
        }
    }
    if (bool) {
        bundleid = $("input[name='bundleid']").val();
    }

    let requiredamount = -1;
    requiredamount = parseFloat($("input[name='amountOptions']").val());
    let amountGiven = $('#sup-amount').val();
    if (requiredamount > amountGiven) {
        alert('The given Donation must be higher than the selected bundle !');
        return 0;
    }

    if (checkWallet(amountGiven)== false) {
        alert('Not enough money in wallet !');
        return 0;
    }
    let formData = {
        id: id,       
        amount: amountGiven,
        backerId: backerId,
        bundleId: bundleid,       
    };

    $.ajax({
        url: actionUrl,
        data: JSON.stringify(formData),
        contentType: 'application/json',
        type: "PUT",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#support-project-success').show();
            window.location.href = "/backermenu/bdashboard?id=" + backerId;
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
            window.location.href = "/home"
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
    let actionUrl = '/api/creator/update/' + id
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
            window.location.href = "/creatormenu/cdashboard";
        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
$('#delete-profile-creator').on('click', () => {
    deleteCreator();
});

function deleteCreator() {
    let id = getUserId();
    let actionUrl = "/api/Creator/delete/" + id    //<----------
    let $successAlert = $('#delete-profile-creator-success');

    $.ajax({
        url: actionUrl,
        contentType: 'application/json',
        type: "PUT",
        success: function (data) {
            $successAlert.fadeIn(500);
            $('#delete-profile-creator-success').hide();
            localStorage.removeItem('userId');
            localStorage.removeItem('backerId');
            localStorage.removeItem('creatorId');
            $('#logout-btn').hide();          
            window.location.href = "/home";

        },
        error: function (jqXhr, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

$('#creator-dashboard').on('click', () => {
    CreatorDashboard();
});

$('#bDashCreator').on('click', () => {
    CreatorDashboard();
});

function CreatorDashboard() {
    var profileUserId = localStorage.getItem('userId');
    window.location.href = window.location.origin + '/creatormenu' + '/CDashBoard?id=' + profileUserId;
}

//====================== P R O J E C T S =======================

$('#create-project').on('click', () => {
    addProject();
});

function addProject() {    
    let actionUrl = '/api/project/create';
    let $successAlert = $('#create-project-success');
    let id = getUserId();
    /////-------------------------
    var input = document.getElementById('Picture');
    var files = input.files;
    var formData = new FormData();
    for (var i = 0; i != files.length; i++) {
        formData.append("Picture", files[i]);
    }
    formData.append("id", parseInt(id));
    formData.append("title", $('#title').val());
    formData.append("description", $('#description').val());
    formData.append("goal", $('#goal').val());
    formData.append("endDate", $('#endDate').val().toString());
    ///--------------------------------

    var checkboxes = document.getElementsByName("categoryOptions");
    for (var i = 0; i != checkboxes.length; i++) {
        if (checkboxes[i].checked) {
            var v = checkboxes[i].value;
        }
    }


    formData.append("category", parseInt(v));
     $.ajax({
        url: actionUrl,
        data: formData,
        processData: false,
        contentType: false,
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
    actionUrl = "/api/project/update/" + id    //<----------
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
    let category = $('#txt-search-tag').val();
    

    let requestData = {
        title: title,
        description: description,
        category : category
    }

    $.ajax({
        url: '/BackerMenu/GetProjects',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(requestData),
        success: function (projects) {
            $('#projects-list-card').html('');

            for (let i = 0; i < projects.length; i++) {
                //if (${ projects[i].category }== category){
                $('#projects-list-card').append(`
                    <div class="card border-left-primary shadow  py-2" style="background-color:#e9f1f7">
                    <div class="card-body">

                        <div class="text-xs font-weight-bold text text-uppercase mb-1" style="color:#2c4a58">
                            <a id="proj-titles" class="nav-link active text-light" href="/BackerMenu/ProjectView/${projects[i].id}" style="background-color:#43444d;border-radius:10px" >${projects[i].title} <span class="badge badge-success">Matching</span></a> 
                        </div>  <!-- Make it pop up only for new ones -->
                            <!-- Progress -->
                            <div class="h5 mb-0 mr-3 font-weight-bold text" style="color:#2c4a58">Goal Completion:${projects[i].progress} %</div>

                        <div class="progress">
                            <div id="one" class="progress-bar-striped progress-bar-animated" role="progressbar" aria-valuenow="@Math.Round(${projects[i].progress})" aria-valuemin="0" aria-valuemax="100" style="width:"@Math.Round(${projects[i].progress})%";background-color:#2c4a58;">
                            </div>
                        </div>
                      

                        </div>
                </div>
                `);
        //}


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
            window.open("/CreatorMenu/CDashboard?id=" + data.userId, "_self")
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
            window.open("/BackerMenu/BDashboard?id=" + data.userId, "_self")
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

if (getUserId() || getBackerId() || getCreatorId()) {
    $('#logout-btn').show();
}
if (getBackerId() ){
    $('#b1').hide();
    $('#b2').hide();
    $('#bDashBacker').show();
    $('#bDashCreator').hide();
}

if (getCreatorId() ){
    $('#b1').hide();
    $('#b2').hide();
    $('#bDashBacker').hide();
    $('#bDashCreator').show();
}


$('#logout-btn').on('click', function () {
    localStorage.removeItem('userId');
    localStorage.removeItem('backerId');
    localStorage.removeItem('creatorId');
    window.location.href = "/home";
    $('#logout-btn').hide();
});

