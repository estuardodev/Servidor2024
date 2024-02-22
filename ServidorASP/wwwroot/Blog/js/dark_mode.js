const toggleSwitch = document.querySelector("input[type='checkbox']");

toggleSwitch.addEventListener("change", switchTheme, false);

function switchTheme(e) {
  if (e.target.checked) {
    document.body.classList.add("dark-mode");
    setCookie("dark-mode", "true", 30);
  } else {
    document.body.classList.remove("dark-mode");
    setCookie("dark-mode", "false", 30);
  }
}

function setCookie(cname, cvalue, exdays) {
  var d = new Date();
  d.setTime(d.getTime() + exdays * 24 * 60 * 60 * 1000);
  var expires = "expires=" + d.toUTCString();
  document.cookie = cname + "=" + cvalue + ";" + expires + ";path=/";
}

function getCookie(cname) {
  var name = cname + "=";
  var decodedCookie = decodeURIComponent(document.cookie);
  var ca = decodedCookie.split(";");
  for (var i = 0; i < ca.length; i++) {
    var c = ca[i];
    while (c.charAt(0) == " ") {
      c = c.substring(1);
    }
    if (c.indexOf(name) == 0) {
      return c.substring(name.length, c.length);
    }
  }
  return "";
}

const darkMode = getCookie("dark-mode");

if (darkMode == "true") {
  document.body.classList.add("dark-mode");
  toggleSwitch.setAttribute("checked", true);
}

