QuickCompare
============

Compare 2 URLs for speed using embedded code

Start of PHP Page:
	$time = microtime(TRUE);

After code you want to check ran
	echo "seconds " . (microtime(TRUE) - $time);
	