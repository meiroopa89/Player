// script.js

$(document).ready(function() {
    // Change text on button click
    $('#changeTextBtn').click(function() {
      $('#targetParagraph').text('Hello, jQuery!');
    });


    $('#changeTextBtn').hover(
        function() {
          $('#changeTextBtn').css('background-color', 'red');
        },
        function() {
          // Reset text color when not hovered
          $('#changeTextBtn').css('background-color', '');
        }
      );
  
    // Change background color on hover
    $('#targetParagraph').hover(
      function() {
        $(this).css('color', 'red');
      },
      function() {
        $(this).css('color', '');
      }
    );
  });
  