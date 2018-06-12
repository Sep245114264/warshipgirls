function showChessAnimation(changeX, changeY, changeTile, animateTime)
{
	var chess_cell = $('#chess_cell_' + changeX + '_' + changeY);
	chess_cell.css('width', 75);
	chess_cell.css('height', 75);
	chess_cell.animate({
		width:50,
		height:50
	}, animateTime);
	if( changeTile == 1 )
	{
		chess_cell.css('background', 'url(grass.png)');
		//chess_cell.css('background-color', 'black');
	}
	else 
	{
		chess_cell.css('background', 'url('+statQuincy+')');
		//chess_cell.css('background-color', 'white');
	}
}

function showFlipChessAnimation(changeX, changeY, changeTile)
{
	board[changeX][changeY] = changeTile;
	var chess_cell = $('#chess_cell_' + changeX + '_' + changeY);
	chess_cell.animate({
		width:0,
		height:0
	}, 200, function()
	{
		var chess_cell = $('#chess_cell_' + changeX + '_' + changeY);
		chess_cell.animate({
			width:50,
			height:50
		}, 200);
		if( changeTile == 1 )
		{
			chess_cell.css('background', 'url(grass.png)');
			//chess_cell.css('background-color', 'black');
		}
		else 
		{
			chess_cell.css('background', 'url(0v0_eat.png)');
			//chess_cell.css('background-color', 'white');
		}
	});
}

function displayQuincy()
{
	$('#Quincy').fadeIn(2000);
	$('#stat_0v0').attr("src", '0v0_hungry_ico.png');
	statQuincy = "0v0_hungry.png"
	updateView();
}

function hideQuincy()
{
	$('#Quincy').fadeOut();
	$('#stat_0v0').attr("src", '0v0_normal_ico.png');
	statQuincy = "0v0_normal.png";
	updateView();
}
