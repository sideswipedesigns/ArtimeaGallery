<?php if (!defined('ABSPATH')) die('No direct access allowed'); ?>
<?php

class TMM_HelperFonts {

	public static function get_google_fonts() {

		$google_fonts = TMM_OptionsHelper::$google_fonts;

		$saved_google_fonts = self::get_saved_google_fonts();

		if (!empty($saved_google_fonts) AND is_array($saved_google_fonts)) {
			foreach ($saved_google_fonts as $font_name => $types) {
				if (empty($types)) {
					$google_fonts[] = $font_name;
				} else {
					$font_string = $font_name . ":";
					$type_num = 0;
					foreach ($types as $type => $num) {
						if ($type_num > 0) {
							$font_string.=",";
						}
						if ($type == "regular") {
							$type = "400" . $type;
						}
						$font_string.=$type;
						$type_num++;
					}
					$google_fonts[] = $font_string;
				}
			}
		}

		return $google_fonts;
	}

	//ajax
	public static function get_google_fonts_ajax() {
		echo json_encode(array_merge(self::get_content_fonts(), self::get_google_fonts()));
		exit;
	}

	//****


	private static function get_saved_google_fonts() {
		$saved_google_fonts = TMM::get_option('saved_google_fonts');
		if (isset($saved_google_fonts['saved_google_fonts'])) {
			return $saved_google_fonts['saved_google_fonts'];
		}
	}

	public static function get_content_fonts() {
		return TMM_OptionsHelper::$content_fonts;
	}

	public static function get_new_google_fonts() {
		$result = array();
		$api_url = TMM_THEME_URI . "/helper/json_google_fonts.php";
		$fonts = file_get_contents($api_url);                
		$result['new_fonts'] = $fonts;
		$result['saved_fonts'] = json_encode(self::get_saved_google_fonts());
		echo json_encode($result);
		exit;
	}

	//ajax
	public static function save_google_fonts() {
		$data = array();
		parse_str($_REQUEST['values'], $data);
		TMM::update_option('saved_google_fonts', $data);
		exit;
	}

	public static function get_google_fonts_link() {
		$fonts = self::get_google_fonts();
		$google_fonts = "";
		foreach ($fonts as $key => $font_name) {
			$font_name = str_replace(" ", "+", $font_name);
			if ($key > 0) {
				$google_fonts.="|";
			}
			$google_fonts.=$font_name;
		}


		return "<link href='http://fonts.googleapis.com/css?family=" . $google_fonts . "' rel='stylesheet' type='text/css'>";
	}

}

