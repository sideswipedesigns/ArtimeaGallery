jQuery(document).ready(function() {
	jQuery(".drag_contact_form_list").sortable();
	//add form
	jQuery('.add_form').click(function() {
		jQuery(".contact_forms_groups_list .js_no_one_item_else").remove();

		var html=jQuery("#contact_form_template").html();
		var index=get_time_miliseconds();

		var new_contact_form_name=jQuery("#new_contact_form_name").val();
		if(!new_contact_form_name){
			return;
		}
		jQuery("#new_contact_form_name").val("");

		html = html.replace(/__INIQUE_ID__/gi,index);
		html = html.replace(/__FORM_NAME__/gi,new_contact_form_name);
		jQuery("#contact_forms").prepend("<div id='contact_form_"+index+"' class='tab-content' style='display:none;'>"+html+"</li>");

		//*****
		jQuery(".contact_forms_groups_list").eq(0).append('<li style="display:none;"><a href="#contact_form_'+index+'">'+new_contact_form_name+'</a></li>');
		jQuery(".contact_forms_groups_list").eq(1).append('<li><a id-data="contact_form_'+index+'" class="delegate_click" href="#">'+new_contact_form_name+'</a><a href="#" title="'+lang_delete+'" class="remove delete_contact_form" form-list-index="'+index+'"></a><a id-data="contact_form_'+index+'" href="#" title="'+lang_edit+'" class="edit delegate_click"></a></li>');
		
		deinit_tabs();
		init_tabs();
		
		jQuery("[href=#contact_form_"+index+"]").trigger('click');
		jQuery(".drag_contact_form_list").sortable();

		return false;

	});

	//delete form
	jQuery('.delete_contact_form').life('click',function() {
		var form_id=jQuery(this).attr("form-list-index");
		jQuery("#contact_form_"+form_id).hide(hide_delay,function(){
			jQuery("#contact_form_"+form_id).remove();
			jQuery("[href=#contact_form_"+form_id+"]").parent().remove();
			jQuery("[form-list-index="+form_id+"]").parent().remove();
			jQuery(".contact_page_nav_link").trigger('click');
		});
		return false;
	});

	//add field
	jQuery('.add_contact_field_button').life('click',function() {
		var index=jQuery(this).attr("form-id");
		var input_index=get_time_miliseconds();

		var html=jQuery("#contact_form_field_template").html();
		html = html.replace(/__INDEX__/gi,index);
		html = html.replace(/__INPUTINDEX__/gi,input_index);
		jQuery(this).parent().find(".drag_contact_form_list").append(html);

		return false;
	});



	//delete field
	jQuery('.delete_contact_field_button').life('click',function() {
		jQuery(this).parent().hide(hide_delay,function(){
			jQuery(this).closest("li").remove();
		});
		return false;
	});


	//change select attributes
	jQuery('.options_type_select').life('change',function() {
		if(jQuery(this).val() == "select"){
			jQuery(this).parents("li").find(".select_options").eq(0).show(show_delay);
		}else{
			jQuery(this).parents("li").find(".select_options").eq(0).hide(hide_delay);
		}
	});

	//change select form name
	jQuery('.form_name').life('change',function(event) {
		var defaultValue = event.target.defaultValue;
		var newValue = event.target.value;
		jQuery("a:contains("+defaultValue+")").text(newValue);
		event.target.defaultValue=newValue;
	});
});