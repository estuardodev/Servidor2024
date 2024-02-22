window.addEventListener('load', function() {
    var scrollIndicator = document.getElementById('scroll-indicator');
    var scrollPosition = window.scrollY;
    var windowHeight = window.innerHeight;
    var pageHeight = document.body.scrollHeight;
    if (scrollPosition / (pageHeight - windowHeight) < 0.2) {
      scrollIndicator.style.display = 'block';
    } else {
      scrollIndicator.style.display = 'none';
    }
  });
  
  window.addEventListener('scroll', function() {
    var scrollIndicator = document.getElementById('scroll-indicator');
    var scrollPosition = window.scrollY;
    var windowHeight = window.innerHeight;
    var pageHeight = document.body.scrollHeight;
    if (scrollPosition / (pageHeight - windowHeight) < 0.2) {
      scrollIndicator.style.display = 'block';
    } else {
      scrollIndicator.style.display = 'none';
    }
  });
  
  var scrollIndicator = document.getElementById('scroll-indicator');
  scrollIndicator.addEventListener('click', function() {
    window.scroll({
      top: window.innerHeight,
      behavior: 'smooth'
    });
  });
  