board = new Array(8);
hintBoard = new Array(8);
for( var i = 0; i < 8; ++i )
{
	board[i] = new Array(8);
	hintBoard[i] = new Array(8);
}
for( var i = 0; i < 8; ++i )
{
	for( var j = 0; j < 8; ++j )
	{
		board[i][j] = 0;
	}
}

level = 0;

whitePoint = 0;
blackPoint = 0;
count = 0;
computerMove = new Array();
turn = 'black'
turnDisplay = 'black'
index = 0;

$(document).ready(function() {
	$('#dialog').jqm(
	{
		modal: true
	})
	$('#dialog_result').jqm(
	{
		modal: true
	})
	$('#techingWindow').jqm(
	{
	})
	$('#chooseLevel').jqm(
	{
		modal: true
	})
	$('#recmd_ico_point').css('display', 'none');
	$('#chooseLevel').jqmShow();
	/*setTimeout(function() {talkDisplay(++index);}, index * 1000);
	setTimeout(function() {talkDisplay(++index);}, index * 1000);
	setTimeout(function() {talkDisplay(++index);}, index * 1000);*/
	new_game();
})

function new_game()
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			var grid_cell = $('#grid_cell_' + i + '_' + j);
			grid_cell.css("top", 10 + i * (50 + 10));
			grid_cell.css("left", 10 + j * (50 + 10));
		}
	}
	init();
}

function init()
{
	
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			board[i][j] = 0;
		}
	}
	turn = 'black';
	$('#turn').text(turn);
	$('#Quincy').css('display', 'none');
	statQuincy = "/static/warships/0v0_normal.png";
	$('#stat_0v0').attr("src", '/static/warships/0v0_normal_ico.png');
	board[3][3] = 1;
	board[3][4] = 2;
	board[4][3] = 2;
	board[4][4] = 1;
	getHintBoard();
	updateScore();
	updateView();
}

function updateView()
{
	$('.chess_cell').remove();
	$('#turn').empty();
	if( turnDisplay == 'black')
	{
		$('#turn').attr('src', '/static/warships/master.png');
	}
	else
	{
		$('#turn').attr('src', statQuincy);
	}

	updateScore();
	hintBoardToBoard();
	
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			$('#grid_cell_' + i + '_' + j).append('<div class="chess_cell" id="chess_cell_' + i + '_' + j + '"></div>');
			var chess_cell = $('#chess_cell_' + i + '_' + j);
			if( board[i][j] == 3 )
			{
				chess_cell.css('background-color', 'green');
				chess_cell.css('width', '10px');
				chess_cell.css('height', '10px');
			}
			if( board[i][j] != 0 )
			{
				
				if( board[i][j] == 1)
				{
					chess_cell.css('width', '50px');
					chess_cell.css('height', '50px');
					chess_cell.css('background', 'url(/static/warships/grass.png)');
					//chess_cell.css('background-color', 'black');
				}
				else if( board[i][j] == 2 )
				{
					chess_cell.css('width', '50px');
					chess_cell.css('height', '50px');
					chess_cell.css('background', 'url('+statQuincy+')');
					//chess_cell.css('background-color', 'white');
				}
				else if( board[i][j] == 4 )
				{
					chess_cell.css('width', '50px');
					chess_cell.css('height', '50px');
					chess_cell.css('background', 'url(/static/warships/0v0_eat.png)');
					//board[i][j] = 2;
				}
			}
		}
	}
	//boardToHintBoard();				//吃土
}

function getHintBoard()
{
	boardToHintBoard();
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( turn === 'black' )
			{
				isValidMove(i, j, PLAYER);
			}
			else if( turn === 'white' )
			{
				isValidMove(i, j, QUINCY);
			}
		}
	}
	hintBoardToBoard();
}

function isValidMove(xStart, yStart, tile)
{
	var x = xStart;
	var y = yStart;
	var otherTile = 0;
	var otherTiles = 0;
	var direction = [[0, 1], [1, 1], [1, 0], [1, -1], [0, -1], [-1, -1], [-1, 0], [-1, 1]];
	var tileToFlip = new Array();
	var tempArray = new Array();
	
	//如果当前位置不为空或有落子可能
	//表示当前位置是一个非法位置
	if( hintBoard[x][y] != 0 && hintBoard[x][y] != PLAYER_HINT && hintBoard[x][y] != QUINCY_HINT )		
	{
		return false;
	}

	if( tile == PLAYER )
	{
		otherTile = QUINCY;
	}
	else
	{
		otherTile = PLAYER;
	}
	for( var i = 0; i < 8; ++i )
	{
		x = xStart;
		y = yStart;
		x += direction[i][0];
		y += direction[i][1]; 

		//if( isOnBoard(x, y) && (hintBoard[x][y] === otherTile || hintBoard[x][y] === otherTiles) )
		//只有该位置是可落位置才能继续判断
		if( isOnBoard(x, y) && (hintBoard[x][y] === otherTile) )
		{
			x += direction[i][0];
			y += direction[i][1];
			if( !isOnBoard(x, y) )
			{
				continue;
			}
			//while( hintBoard[x][y] === otherTile || hintBoard[x][y] === otherTiles )
			//该位置是不可落子位置，跳出循环
			while( hintBoard[x][y] === otherTile)
			{
				x += direction[i][0];
				y += direction [i][1];
				if( !isOnBoard(x, y) )
				{
					break;
				}
			}
			if( !isOnBoard(x, y) )
			{
				continue;
			}
			//当不可落子的类型为当前行动方的棋子
			if( hintBoard[x][y] == tile )
			{
				while( 1 )
				{
					x -= direction[i][0];
					y -= direction[i][1];
					if( x == xStart && y == yStart )
					{
						if( tile === QUINCY )
						{
							hintBoard[x][y] = QUINCY_HINT;
						}
						else
						{
							hintBoard[x][y] = PLAYER_HINT;
						}
						break;
					}
					tileToFlip.push(x);
					tileToFlip.push(y);
				}
			}
		}
	}
	if( tileToFlip.length )
	{
		return tileToFlip;
	}
	return false;							
}

$(document).ready(function() {
	$('#grid_container').click(function(e) {
	var tile = 1;
	var tiles = new Array();
	if( turn === 'black')
	{
		tile = 1;
		var clickTarget = $(e.target).attr('id');
		var str = new Array(4);
		str = clickTarget.split('_');
		var x = parseInt(str[2]);
		var y = parseInt(str[3]);
		if( isOnBoard(x, y) && hintBoard[x][y] === 3 && !$('#chess_cell_' + x + '_' + y).is(':animated') )
		{
			var tempX;
			var tempY;
			clearHint();
			hintBoardToBoard();
			board[x][y] = 1;
			showChessAnimation(x, y, 1, 200);
			turn = 'white'
			tiles = isValidMove(x, y, 1);
			while( tiles.length )
			{
				tempY = tiles.pop();
				tempX = tiles.pop();
				showFlipChessAnimation(tempX, tempY, 1);
			}
			boardToHintBoard();
			getHintBoard();
			changeChessType();
			setTimeout(function() {turnDisplay = turn; updateView();}, 500);
			isRule(turn);
		}
	}
	
	})
})

function getComputerMove()
{
	//clearHint();
	//hintBoardToBoard();
	//updateView();

	//getHintBoard();
	var bestMove = new Object();
	var index = 0;
	var computerX = bestMove.x;
	var computerY = bestMove.y;
	getVaildMove(2);
	if( level == 0 )
	{
		index = Math.floor(Math.random() * 100 % (count / 2)) * 2;
		computerX = computerMove[index];
		computerY = computerMove[index + 1];
	}
	else
	{
		bestMove = AI();
	 	computerX = bestMove.x;
		computerY = bestMove.y;
	}
	board[computerX][computerY] = 2;
	showChessAnimation(computerX, computerY, 2, 200);
	turn = "black";
	var tiles = isValidMove(computerX, computerY, 2);
	while( tiles.length )
	{
		var tempY = tiles.pop();
		var tempX = tiles.pop();
		showFlipChessAnimation(tempX, tempY, 4);
	}
	clearHint();
	boardToHintBoard();
	getHintBoard();
	hintBoardToBoard();
	
	setTimeout(function() {
		turnDisplay = turn;
		updateView();
		isQuincyWatchingYou(); 
		isRule(turn)
	}, 500);
}

function getVaildMove(tile)
{
	count = 0;
	while( computerMove.length )
	{
		computerMove.pop();
	}
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( isValidMove(i, j, tile) )
			{
				computerMove.push(i);
				computerMove.push(j);
				count += 2;
			}
		}
	}
}

function isChangeTurn(currentTurn)
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( currentTurn == "black" && hintBoard[i][j] == 3 )
			{
				turnDisplay = 'black';
				return false;
			}
			else if( currentTurn == "white" && hintBoard[i][j] == -1 )
			{
				turnDisplay = 'white';
				return false;
			}
		}
	}
	if( currentTurn === 'black' )
	{
		turn = 'white';
	}
	else if( currentTurn === 'white' )
	{
		turn = 'black';
	}
	return true;
}

function isRule(currentTurn)
{
	getHintBoard();
	//isWin();	//判断当前回合是否轮空
	if( isChangeTurn(currentTurn) )
	{
		clearHint();
		getHintBoard();
		
		hintBoardToBoard();
		if( turn == 'black' )
		{
			setTimeout(function() {updateView();isWin();}, 500);
			return;
		}
		else if( turn == 'white' )
		{
			setTimeout(function() {updateView();isWin(); getComputerMove()}, 800);
			return;
		}
	}
	if( turn == 'white' )
	{
		setTimeout(function() {getComputerMove()}, 800);
	}
}

function teching()
{

	$('#techingWindow').jqmShow();
	$('#recmd_ico_point').css('display', 'none');
	$('#techingSection').scrollTop(99999);
}

function vvTalk(strIndex, vvString)
{
	$('#techingSection').append('<div id="techingSection' + strIndex + '"</div>');
	$('#techingSection' + strIndex).append('<div class="vvIco" id="vv' + strIndex + '"><img src="/static/warships/vv.png"></div>');
	$('#techingSection' + strIndex).append('<div class="vvDialogSection" id="vvDia' + strIndex + '"></div>');
	$('#vv' + strIndex).append('<div class="bubble"></div>')
	$('#vvDia' + strIndex).append('<span class="vvDialog">' + vvString + '</span>');
	var vvDia = $('#vvDia' + strIndex);
	if( vvDia.width() > 220 )
	{
		vvDia.css('width', '50%');
	}
	else
	{
		vvDia.css('width', 'auto');
	}
	$('#techingSection').scrollTop(9999);
}

function chiefTalk(strIndex, chiefString)
{
	$('#techingSection').append('<div id="techingSection' + strIndex + '"</div>');
	$('#techingSection' + strIndex).append('<div class="chiefIco" id="chief' + strIndex + '"><img src="/static/warships/chief.png"></div');
	$('#techingSection' + strIndex).append('<div class="chiefDialogSection" id="chiefDia' + strIndex + '"></div>');
	$('#chief' + strIndex).append('<div class="chiefBubble"></div>');
	$('#chiefDia' + strIndex).append('<span class="chiefDialog">' + chiefString + '</span>');
	var chiefDia = $('#chiefDia' + strIndex);
	if( chiefDia.width() > 220 )
	{
		chiefDia.css('width', '50%');
	}
	else
	{
		chiefDia.css('width', 'auto');
	}
	var offset = $('#techingSection' + strIndex).width() - chiefDia.width() - 100;
	chiefDia.css('left', offset);
	$('#techingSection').scrollTop(9999);
}

function talkDisplay(strIndex)
{
	$('#techingSection' + strIndex).css('display', 'block');
	$('#techingSection').scrollTop(9999);
}

function talkNone(strIndex)
{
	$('#techingSection' + strIndex).css('display', 'none');
}