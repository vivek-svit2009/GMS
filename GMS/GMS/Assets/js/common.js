	function loadFile(event) {
		var reader = new FileReader();
		reader.onload = function(){
		  var output = document.getElementById('preview');
		  output.src = reader.result;
		};
		reader.readAsDataURL(event.target.files[0]);
	};
	
		
function clear_form_elements(id_name) {
  jQuery("#"+id_name).find(':input').each(function() {
    switch(this.type) {
        case 'password':
        case 'text':
        case 'textarea':
        case 'file':
        case 'select':
        case 'select-multiple':
        case 'date':
        case 'number':
        case 'tel':
        case 'email':
            jQuery(this).val('');
            break;
        case 'checkbox':
        case 'radio':
            this.checked = false;
            break;
    }
  });
}
