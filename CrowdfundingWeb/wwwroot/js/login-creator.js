// Login Event
$('#creator-login-btn').on('click', () => {
    CheckCreatorLogin();
});

function CheckCreatorLogin() {
    let userEmail = $('#user-email').val();
    let password = $('#user-password').val();

    let loginOptions = {
        email: userEmail,
        password: password
    };
    
    $.ajax({
        url: '/home/login',
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