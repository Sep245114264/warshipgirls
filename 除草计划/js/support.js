const PLAYER = 1;
const QUINCY = 2;
const PLAYER_HINT = 3;
const QUINCY_HINT = -1;
const SOLID = 4;
DECLARE = false;
statQuincy ="/static/warships/0v0_normal.png"
statQuincyIco = "/static/warships/0v0_normal_ico.png";

function hintBoardToBoard()
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			board[i][j] = hintBoard[i][j];
		}
	}
}

function boardToHintBoard()
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			hintBoard[i][j] = board[i][j];
		}
	}
}

function clearHint()
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( hintBoard[i][j] === 3 || hintBoard[i][j] === -1 )
			{
				hintBoard[i][j] = 0;
			}
			if( board[i][j] === 3 || board[i][j] === -1 )
			{
				board[i][j] = 0;
			}
		}
	}
}

function isOnBoard(x, y)
{
	if( x < 0 || y < 0 || x > 7 || y > 7 )
	{
		return false;
	}
	return true;
}

function updateScore()
{
	blackPoint = 0;
	whitePoint = 0;
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			switch( board[i][j] )
			{
				case 1:
					++blackPoint;
					break;
				case 2:
					++whitePoint;
					break;
				case 4:
					++whitePoint;
					break;
			}
		}
	}
	
	if( (blackPoint + whitePoint) > 10 && !DECLARE)
	{
		DECLARE = true;
		$('#recmd_ico_point').css('display', 'inline');
		vvTalk(28, '昆西图片均来源于<a href="https://weibo.com/hikarinoniwa?from=myfollow_all&is_all=1" target="_blank">真名太太</a>');
		vvTalk(29, 'vv头像来源于<a href="https://weibo.com/u/5779260784?from=myfollow_all&is_all=1" target="_blank">刀菌子</a>');
		vvTalk(30, '行动方提督头像来源于游戏<a href="http://www.jianniang.com/" target="_blank">战舰少女R</a>');
		$('#techingSection').scrollTop(9999);
	}
	/*$('#turn').append('<p>blackPoint: ' + blackPoint + '</p>');
	$('#turn').append('<p>whitePoint: ' + whitePoint + '</p>');*/
	$('#points_grass').text(blackPoint);
	$('#points_0v0').text(whitePoint);
}

function isWin()
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( hintBoard[i][j] == 3 || hintBoard[i][j] == -1 )
			{
				return ;
			}
		}
	}
	if( blackPoint > whitePoint )
	{
		$('#result_image').append('<img src="/static/warships/cry.png" id="winImg">');
		$('#closeButton').text("赢了？");
		$('#dialog').jqmShow();
		//alert('black is winner');
	}
	else if( blackPoint < whitePoint )
	{
		$('#dialog').jqmShow();
		$('#result_image').append('<img src="/static/warships/0v0_watchyou.jpg" id="winImg">');
		$('#closeButton').text("输了？");
		//alert('white is winner');
	}
	else
	{
		alert('no winner');
	}
}

function changeChessType()
{
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( board[i][j] === 4 )
			{
				board[i][j] = 2;
			}
		}
	}
}

function isQuincyWatchingYou()
{
	if( whitePoint > blackPoint )
	{
		if( 64 - whitePoint - blackPoint < 16 )
		{
			displayQuincy();
		}
	}
	else
	{
		hideQuincy();
	}
}

function winGame()
{
	$('#dialog').jqmHide();
	$('#result_image').empty();
	if( blackPoint > whitePoint )
	{
		for( var i = 0; i < 8; ++i )
		{
			for( var j = 0; j < 8; ++j )
			{
				if( hintBoard[i][j] == PLAYER )
				{
					hintBoard[i][j] = SOLID;
				}
			}
		}
	}
	else if( blackPoint < whitePoint )
	{
		winnerMaster();
	}
	updateView();
}

function winnerMaster()
{	
	$('#dialog_result').jqmShow();
	$('#result_image_result').append('<img src="/static/warships/0v0.gif" id="winImg_result">');
	$('#result_image_result').append('<img src="/static/warships/win04.png" id="endImg">');
	setTimeout(function() {
		//$('#result_image').empty();
		//$('#result_image').append('<img src="win04.png" id="winImg">')
		$('#winImg_result').css('display', 'none');
		$('#endImg').css('display', 'block');
	}, 3500);
	$('#closeButton_result').text("结束了？");
}

function game_result()
{
	$('#dialog_result').jqmHide();
	$('#result_image_result').empty();
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( hintBoard[i][j] == PLAYER )
			{
				hintBoard[i][j] = QUINCY;
				statQuincy = "/static/warships/0v0_hungry.png";
			}
		}
	}
	updateView();
}

function AI()
{
	var quincyPossition = new Object();
	var tile = new Array();
	var bestScore = 0;
	quincyPossition.x = 0;
	quincyPossition.y = 0;
	getVaildMove(2);
	for( var i = 0; i < computerMove.length; i += 2 )
	{
		quincyPossition.x = computerMove[i];
		quincyPossition.y = computerMove[i + 1];
		if( isConner(quincyPossition.x, quincyPossition.y) )
		{
			return quincyPossition;
		}
	}

	var bestMove = new Object();
	var copyBoard = new Array();
	for( var i = 0; i < computerMove.length; i += 2 )
	{
		quincyPossition.x = computerMove[i];
		quincyPossition.y = computerMove[i + 1];
		copyBoard = getCopyBoard();
		
		tile = AIValidMove(quincyPossition.x, quincyPossition.y, 2, copyBoard);
		while( tile.length )
		{
			var tempY = tile.pop();
			var tempX = tile.pop();
			copyBoard[tempX][tempY] = QUINCY;
		}
		copyBoard[quincyPossition.x][quincyPossition.y] = 2;
		if( AIScore(copyBoard) > bestScore )
		{
			bestScore = AIScore(copyBoard);
			bestMove.x = quincyPossition.x;
			bestMove.y = quincyPossition.y;
		}
	}
	return bestMove;
}

function isConner(x, y)
{
	if( (x == 0 && y == 0) || (x == 0 && y == 7) || (x == 7 && y == 0) || (x == 7 && y == 7) )
	{
		return true;
	}
	else
	{
		return false;
	}
}

function getCopyBoard()
{
	var tempBoard = new Array();
	for( var i = 0; i < 8; ++i )
	{
		tempBoard[i] = new Array();
	}

	clearHint();

	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			tempBoard[i][j] = hintBoard[i][j];
		}
	}
	return tempBoard;
}

function AIValidMove(xStart, yStart, tile, tempBoard)
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
	if( tempBoard[x][y] != 0 && tempBoard[x][y] != PLAYER_HINT && tempBoard[x][y] != QUINCY_HINT )		
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
		if( isOnBoard(x, y) && (tempBoard[x][y] === otherTile) )
		{
			x += direction[i][0];
			y += direction[i][1];
			if( !isOnBoard(x, y) )
			{
				continue;
			}
			//while( hintBoard[x][y] === otherTile || hintBoard[x][y] === otherTiles )
			//该位置是不可落子位置，跳出循环
			while( tempBoard[x][y] === otherTile)
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
			if( tempBoard[x][y] == tile )
			{
				while( 1 )
				{
					x -= direction[i][0];
					y -= direction[i][1];
					if( x == xStart && y == yStart )
					{
						if( tile === QUINCY )
						{
							tempBoard[x][y] = QUINCY_HINT;
						}
						else
						{
							tempBoard[x][y] = PLAYER_HINT;
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

function AIScore(copyBoard)
{
	var score = 0;
	for( var i = 0; i < 8; ++i )
	{
		for( var j = 0; j < 8; ++j )
		{
			if( copyBoard[i][j] == QUINCY || copyBoard[i][j] == SOLID )
			{
				++score;
			}
		}
	}
	return score;
}

function changeLevel(tempLevel)
{
	level = tempLevel;
	if( level == 0)
	{
		$('#level').text("0v0");
	}
	else
	{
		$('#level').text('鲲');
	}
	$("#chooseLevel").jqmHide();
	$('#recmd').click();
	vvTalk(++index, "Buongiorno signor ammiraglio。");
	vvTalk(++index, '您终于来了，别忘记要做的工作。');
	chiefTalk(++index, '工作？什么工作？');
	vvTalk(++index, '您离开的太久了，大家都出去玩儿了。');
	vvTalk(++index, '现在港区里只有你和昆西两个人。');
	vvTalk(++index, '而您的工作就是保护好自己和港区。(笑)');
	chiefTalk(++index, '我该怎么做？');
	vvTalk(++index, '给您一点提示。');
	vvTalk(++index, '只要您种草的横、竖、斜八个方向有一棵草');
	vvTalk(++index, '昆西就会犹豫，而您就有时间在那一条线上全部种上草。');
	vvTalk(++index, '同样的，只要两边各有一只昆西，她们的中间的草就会被全部吃完。');
	vvTalk(++index, '需要注意的是，昆西吃草的时候可是赶不走的。');
	vvTalk(++index, '而且您的每一步必须是有效的。');
	vvTalk(++index, '也就是说每一步都要至少赶走一只昆西。');
	chiefTalk(++index, '那如果我找不到怎么办？');
	vvTalk(++index, '关于这一点，您不用担心，我会把所有有效的位置显示出来。');
	vvTalk(++index, '如果真的没有，那就只能放弃这一轮了。');
	vvTalk(++index, '最后，祝您好运。Amore mio。');
	for( var i = 1; i <= index; ++i )
	{
		talkNone(i);
	}
	var i = 0;
	for( i = 1; i <= index; ++i )
	{
		/*alert(i);
		talkDisplay(i);*/

		(function(i){
		setTimeout(function() {talkDisplay(i);}, i * 1000);})(i);
	}
}