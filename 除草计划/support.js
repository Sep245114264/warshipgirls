const PLAYER = 1;
const QUINCY = 2;
const PLAYER_HINT = 3;
const QUINCY_HINT = -1;
const SOLID = 4;
DECLARE = false;
statQuincy ="0v0_normal.png"
statQuincyIco = "0v0_normal_ico.png";

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
		vvTalk(28, '昆西图片均来源于<a href="https://weibo.com/hikarinoniwa?from=myfollow_all&is_all=1">真名太太</a>');
		vvTalk(29, 'vv头像来源于<a href="https://weibo.com/u/5779260784?from=myfollow_all&is_all=1">刀菌子</a>');
		vvTalk(30, '行动方提督头像来源于游戏<a href="http://www.jianniang.com/">战舰少女R</a>');
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
		$('#result_image').append('<img src="cry/cry.png" id="winImg">');
		$('#closeButton').text("赢了？");
		$('#dialog').jqmShow();
		//alert('black is winner');
	}
	else if( blackPoint < whitePoint )
	{
		$('#dialog').jqmShow();
		$('#result_image').append('<img src="0v0_watchyou.jpg" id="winImg">');
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
	$('#result_image_result').append('<img src="0v0.gif" id="winImg_result">');
	setTimeout(function() {
		//$('#result_image').empty();
		//$('#result_image').append('<img src="win04.png" id="winImg">')
		$('#winImg_result').attr('src', 'win04.png');
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
				statQuincy = "0v0_hungry.png";
			}
		}
	}
	updateView();
}