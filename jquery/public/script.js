// script.js

$(document).ready(function() {
    // Change text on button click
    $('#changeTextBtn').click(function() {
      $('#targetParagraph').text('Hello, jQuery!');
    });
  
    // Change background color on hover
    $('#targetParagraph').hover(
      function() {
        $(this).css('background-color', 'lightgray');
      },
      function() {
        $(this).css('background-color', '');
      }
    );
  });
  