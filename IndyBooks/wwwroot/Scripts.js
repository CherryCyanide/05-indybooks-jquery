    /* DONE: NOTHING TO CHANGE HERE. BUT FOUR NESTED FUNCTIONS!!!!
        The JavaScript Library called "jQuery" provides a 'tooltip' function that calls
         'getJSON(/api/writer/{id}/bookcount, ... )  when user hovers over rows with a 'data-id'.
        The resulting data is processed by the anonymous 'function(data)' which creates the
        text to display as 'Author Book Count: + data.count' different for each 'data-id'  row
    */
$(function () {
    $(document).tooltip({
        items: "[data-id]", /* hovering over these elements will call the function below */
        content: function(){
            /* Get the book id from the HTML */
            var id = this.attributes["data-id"].nodeValue;
            /* Call the API */
            $.getJSON('/api/writers/' + id + '/bookcount', function (data) {
                /* uses JS to add a title attribute to the hovered item */
                $("[data-id =" + id + "]")
                    /* creates the title using the JSON 'data' from the API */
                    .attr('title', 'Author Book Count: ' + data.count)
            });
        }
    });
 });    