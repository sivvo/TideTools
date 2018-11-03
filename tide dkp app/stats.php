<?php
/******************************
 * EQdkp
 * Copyright 2002-2003
 * Licensed under the GNU GPL.  See COPYING for full terms.
 * ------------------
 * stats.php
 * Began: Sat December 21 2002
 *
 * $Id: stats.php,v 1.14 2003/10/04 19:37:37 tsigo Exp $
 *
 ******************************/

define('EQDKP_INC', true);
$eqdkp_root_path = './';
include_once($eqdkp_root_path . 'common.php');

$user->check_auth('u_member_list');

$sort_order = array(
     0 => array('member_name', 'member_name desc'),
     1 => array('member_firstraid', 'member_firstraid desc'),
     2 => array('member_lastraid', 'member_lastraid desc'),
     3 => array('member_raidcount desc', 'member_raidcount'),
     4 => array('member_earned desc', 'member_earned'),
     5 => array('earned_per_day desc', 'earned_per_day'),
     6 => array('earned_per_raid desc', 'earned_per_raid'),
     7 => array('member_spent desc', 'member_spent'),
     8 => array('spent_per_day desc', 'spent_per_day'),
     9 => array('spent_per_raid desc', 'spent_per_raid'),
    10 => array('lost_to_adjustment desc', 'lost_to_adjustment'),
    11 => array('lost_to_spent desc', 'lost_to_spent'),
    12 => array('member_current desc', 'member_current')
);

$current_order = switch_order($sort_order);


// Find 30 days ago, then find how many raids occurred in those 30 days
// Do the same for 60 and 90 days
$thirty_days = mktime(0, 0, 0, date('m'), date('d')-30, date('Y'));
$sixty_days  = mktime(0, 0, 0, date('m'), date('d')-60, date('Y'));
$ninety_days = mktime(0, 0, 0, date('m'), date('d')-90, date('Y'));

$total_raids   = $db->query_first('SELECT count(*) FROM ' . RAIDS_TABLE);
// Hack for 30/60/90 days attendance
$raid_count_30 = $db->query_first('SELECT count(*) FROM ' . RAIDS_TABLE . ' WHERE raid_date BETWEEN '.$thirty_days.' AND '.time());
$raid_count_60 = $db->query_first('SELECT count(*) FROM ' . RAIDS_TABLE . ' WHERE raid_date BETWEEN '.$sixty_days.' AND '.time());
$raid_count_90 = $db->query_first('SELECT count(*) FROM ' . RAIDS_TABLE . ' WHERE raid_date BETWEEN '.$ninety_days.' AND '.time());


$show_all = ( (!empty($_GET['show'])) && ($_GET['show'] == "all") ) ? true : false;

// No idea if this massive query will work outside MySQL...if not, we'll have
// to use a switch and get the values another way
$sql = 'SELECT member_name, member_earned, member_spent, member_adjustment,
        (member_earned-member_spent+member_adjustment) AS member_current,
        member_firstraid, member_lastraid, member_raidcount,
        ((member_spent/member_earned)*100) AS lost_to_spent,
        ((member_adjustment-(member_adjustment*2))/member_earned)*100 AS lost_to_adjustment,
        member_earned/(('.time().' - member_firstraid) / 86400) AS earned_per_day,
        member_spent/(('.time().' - member_firstraid) / 86400) AS spent_per_day,
        member_earned/member_raidcount AS earned_per_raid,
        member_spent/member_raidcount AS spent_per_raid,
        r.rank_prefix, r.rank_suffix
        FROM ' . MEMBERS_TABLE . ' m
        LEFT JOIN ' . MEMBER_RANKS_TABLE . ' r
        ON (m.member_rank_id = r.rank_id)';

if ( ($eqdkp->config['hide_inactive'] == 1) && (!$show_all) )
{
    $sql .= " WHERE member_status='1'";
}
$sql .= ' ORDER BY '.$current_order['sql'];

if ( !($members_result = $db->query($sql)) )
{
    message_die('Could not obtain member information', '', __FILE__, __LINE__, $sql);
}
while ( $row = $db->fetch_record($members_result) )
{
    // Default the values of these in case they have no earned or spent or
    // adjustment
    $row['earned_per_day'] = (!empty($row['earned_per_day'])) ? $row['earned_per_day'] : '0.00';
    $row['earned_per_raid'] = (!empty($row['earned_per_raid'])) ? $row['earned_per_raid'] : '0.00';
    $row['spent_per_day'] = (!empty($row['spent_per_day'])) ? $row['spent_per_day'] : '0.00';
    $row['spent_per_raid'] = (!empty($row['spent_per_raid'])) ? $row['spent_per_raid'] : '0.00';
    $row['lost_to_adjustment'] = (!empty($row['lost_to_adjustment'])) ? $row['lost_to_adjustment'] : '0.00';
    $row['lost_to_spent'] = (!empty($row['lost_to_spent'])) ? $row['lost_to_spent'] : '0.00';

    // Find out how many days it's been since their first raid
    $days_since_start = 0;
    $days_since_start = round((time() - $row['member_firstraid']) / 86400);


    // You asked for it.  Do you have *any* idea how slow this query is?
    // THREE searches WITH A JOIN!!! on the 2 largest tables in the database.
    // It works, tho.

    $sql = 'SELECT count(ra.raid_id) AS raid_count
            FROM ' . RAID_ATTENDEES_TABLE . ' ra, ' . RAIDS_TABLE . " r
            WHERE (r.raid_id = ra.raid_id)
            AND (ra.member_name = '" . $row['member_name'] . "')
            AND (r.raid_date >= " .$thirty_days. ")
            GROUP BY ra.member_name";
    $member_raidcount_30 = $db->query_first($sql);

    $sql = 'SELECT count(ra.raid_id) AS raid_count
            FROM ' . RAID_ATTENDEES_TABLE . ' ra, ' . RAIDS_TABLE . " r
            WHERE (r.raid_id = ra.raid_id)
            AND (ra.member_name = '" . $row['member_name'] . "')
            AND (r.raid_date >= " .$sixty_days. ")
            GROUP BY ra.member_name";
    $member_raidcount_60 = $db->query_first($sql);

    $sql = 'SELECT count(ra.raid_id) AS raid_count
            FROM ' . RAID_ATTENDEES_TABLE . ' ra, ' . RAIDS_TABLE . " r
            WHERE (r.raid_id = ra.raid_id)
            AND (ra.member_name = '" . $row['member_name'] . "')
            AND (r.raid_date >= " .$ninety_days. ")
            GROUP BY ra.member_name";
    $member_raidcount_90 = $db->query_first($sql);


    // Find the percentage of raids they've been on
    $attended_percent = ( $total_raids > 0 ) ? round(($row['member_raidcount'] / $total_raids) * 100) : 0;
    $attended_percent_30 = ( $raid_count_30 > 0 ) ? round(($member_raidcount_30 / $raid_count_30) * 100) : 0;
    $attended_percent_60 = ( $raid_count_60 > 0 ) ? round(($member_raidcount_60 / $raid_count_60) * 100) : 0;
    $attended_percent_90 = ( $raid_count_90 > 0 ) ? round(($member_raidcount_90 / $raid_count_90) * 100) : 0;

    $db->free_result($member_raidcount_30);
    $db->free_result($member_raidcount_60);
    $db->free_result($member_raidcount_90);

    $tpl->assign_block_vars('stats_row', array(
        'ROW_CLASS' => $eqdkp->switch_row_class(),
        'U_VIEW_MEMBER' => 'viewmember.php'.$SID.'&amp;' . URI_NAME . '='.$row['member_name'],
        'NAME' => $row['rank_prefix'] . $row['member_name'] . $row['rank_suffix'],
        'FIRST_RAID' => ( !empty($row['member_firstraid']) ) ? date($user->style['date_notime_short'], $row['member_firstraid']) : '&nbsp;',
        'LAST_RAID' => ( !empty($row['member_lastraid']) ) ? date($user->style['date_notime_short'], $row['member_lastraid']) : '&nbsp;',
        'ATTENDED_COUNT' => $row['member_raidcount'],
        'C_ATTENDED_PERCENT' => color_item($attended_percent, true),
        'C_ATTENDED_PERCENT_30' => color_item($attended_percent_30, true),
        'C_ATTENDED_PERCENT_60' => color_item($attended_percent_60, true),
        'C_ATTENDED_PERCENT_90' => color_item($attended_percent_90, true),
        'ATTENDED_PERCENT' => $attended_percent,
        'ATTENDED_PERCENT_30' => $attended_percent_30,
        'ATTENDED_PERCENT_60' => $attended_percent_60,
        'ATTENDED_PERCENT_90' => $attended_percent_90,
        'EARNED_TOTAL' => $row['member_earned'],
        'EARNED_PER_DAY' => sprintf("%.2f", $row['earned_per_day']),
        'EARNED_PER_RAID' => sprintf("%.2f", $row['earned_per_raid']),
        'SPENT_TOTAL' => $row['member_spent'],
        'SPENT_PER_DAY' => sprintf("%.2f", $row['spent_per_day']),
        'SPENT_PER_RAID' => sprintf("%.2f", $row['spent_per_raid']),
        'LOST_TO_ADJUSTMENT' => sprintf("%.2f", $row['lost_to_adjustment']),
        'LOST_TO_SPENT' => sprintf("%.2f", $row['lost_to_spent']),
        'C_CURRENT' => color_item($row['member_current']),
        'CURRENT' => $row['member_current'])
    );
}

if ( ($eqdkp->config['hide_inactive'] == 1) && (!$show_all) )
{
    $footcount_text = sprintf($user->lang['stats_active_footcount'], $db->num_rows($members_result),
                              '<a href="stats.php'.$SID.'&amp;o='.$current_order['uri']['current'].'&amp;show=all" class="rowfoot">');
}
else
{
    $footcount_text = sprintf($user->lang['stats_footcount'], $db->num_rows($members_result));
}

// Class Statistics
// Class Summary
// Classes array - if an element is false, that class has gotten no
// loot and won't show up from the SQL query
// Otherwise it contains an array with the SQL data
$eq_classes = array(
    'Bard' => false,
    'Beastlord' => false,
    'Cleric' => false,
    'Druid' => false,
    'Enchanter' => false,
    'Magician' => false,
    'Monk' => false,
    'Necromancer' => false,
    'Paladin' => false,
    'Ranger' => false,
    'Rogue' => false,
    'Shadow Knight' => false,
    'Shaman' => false,
    'Warrior' => false,
    'Wizard' => false);

// Find the total members existing with a class
$sql = 'SELECT count(member_id)
        FROM ' . MEMBERS_TABLE . '
        WHERE member_class IS NOT NULL';
$total_members = $db->query_first($sql);

// Find the total priced items
$sql = 'SELECT count(item_id)
        FROM ' . ITEMS_TABLE . '
        WHERE item_value != 0.00';
$total_drops = $db->query_first($sql);

// Find out how many members of each class exist
$class_counts = array();
$sql = 'SELECT member_class, count(member_id) AS class_count
        FROM ' . MEMBERS_TABLE . '
        GROUP BY member_class';
$result = $db->query($sql);
while ( $row = $db->fetch_record($result) )
{
    $class_counts[ $row['member_class'] ] = $row['class_count'];
}
$db->free_result($result);

// Query finds all items purchased by each class
// Will not find items that are unpriced, will not find members that don't have a class defined
$sql = 'SELECT m.member_class, count(i.item_id) AS class_drops
        FROM ' . ITEMS_TABLE . ' i, ' . MEMBERS_TABLE . " m
        WHERE (m.member_name = i.item_buyer)
        AND (i.item_value != 0.00)
        AND (m.member_class IS NOT NULL)
        GROUP BY m.member_class";
$result = $db->query($sql);
while ( $row = $db->fetch_record($result) )
{
    $class = $row['member_class'];
    $class_drops = $row['class_drops'];
    $class_drop_pct = ( $total_drops > 0 ) ? round(($class_drops / $total_drops) * 100) : 0;

    $class_members = ( isset($class_counts[$class]) ) ? $class_counts[$class] : 0;
    $class_factor = ( $class_members > 0 ) ? round(($class_drops / $class_members) * 100) : 0;

    if ( isset($eq_classes[$class]) )
    {
        $eq_classes[$class] = array(
            'drops' => $class_drops,
            'drop_pct' => $class_drop_pct,
            'class_count' => $class_members,
            'class_pct' => ( $total_members > 0 ) ? round(($class_members / $total_members) * 100) : 0,
            'factor' => $class_factor);
    }
}
$db->free_result($result);

// We still need to find out how many of the class exist
$sql = 'SELECT member_class, count(member_id) as class_count
        FROM ' . MEMBERS_TABLE . '
        GROUP BY member_class';
$result = $db->query($sql);

while ( $row = $db->fetch_record($result) )
{
    $class = $row['member_class'];
    $class_count = $row['class_count'];

    if( (empty($class)) || ($class == 'NULL') )
    {
        continue;
    }

    // if this isn't an array, define blank values
    if ( !is_array($eq_classes[$class]) )
    {
        $v = array(
            'drops' => 0,
            'drop_pct' => 0,
            'class_count' => $class_count,
            'class_pct' => ( $total_members > 0 ) ? round(($class_count / $total_members) * 100) : 0,
            'factor' => 0
        );
    }
    else
    {
        $v = $eq_classes[$class];
    }

    $row_class = ( (!empty($_GET['class'])) && ($_GET['class'] == $k) ) ? 'rowhead' : $eqdkp->switch_row_class();

    $loot_factor = ( $v['class_pct'] > 0 ) ? round((($v['drop_pct'] / $v['class_pct']) - 1) * 100) : '0';

    $tpl->assign_block_vars('class_row', array(
        'ROW_CLASS' => $row_class,
        'LINK_CLASS' => ( $row_class == 'rowhead' ) ? 'header' : '',
        'U_LIST_MEMBERS' => 'listmembers.php' . $SID . '&amp;filter=' . strtolower($class),
        'CLASS' => $class,
        'LOOT_COUNT' => $v['drops'],
        'LOOT_PCT' => sprintf("%d%%", $v['drop_pct']),
        'CLASS_COUNT' => $v['class_count'],
        'CLASS_PCT' => sprintf("%d%%", $v['class_pct']),
        'LOOT_FACTOR' => sprintf("%d%%", $loot_factor),
        'C_LOOT_FACTOR' => color_item($loot_factor))
    );
}

$tpl->assign_vars(array(
    'L_NAME' => $user->lang['name'],
    'L_RAIDS' => $user->lang['raids'],
    'L_EARNED' => $user->lang['earned'],
    'L_SPENT' => $user->lang['spent'],
    'L_PCT_EARNED_LOST_TO' => $user->lang['pct_earned_lost_to'],
    'L_CURRENT' => $user->lang['current'],
    'L_FIRST' => $user->lang['first'],
    'L_LAST' => $user->lang['last'],
    'L_ATTENDED' => $user->lang['attended'],

    'L_RAIDS_30_DAYS' => sprintf($user->lang['raids_x_days'], 30),
    'L_RAIDS_60_DAYS' => sprintf($user->lang['raids_x_days'], 60),
    'L_RAIDS_90_DAYS' => sprintf($user->lang['raids_x_days'], 90),

    'L_TOTAL' => $user->lang['total'],
    'L_PER_DAY' => $user->lang['per_day'],
    'L_PER_RAID' => $user->lang['per_raid'],
    'L_ADJUSTMENT' => $user->lang['adjustment'],

    'L_CLASS' => $user->lang['class'],
    'L_LOOTS' => $user->lang['loots'],
    'L_MEMBERS' => $user->lang['members'],
    'L_LOOT_FACTOR' => $user->lang['loot_factor'],

    'O_NAME' => $current_order['uri'][0],
    'O_FIRSTRAID' => $current_order['uri'][1],
    'O_LASTRAID' => $current_order['uri'][2],
    'O_RAIDCOUNT' => $current_order['uri'][3],
    'O_EARNED' => $current_order['uri'][4],
    'O_EARNED_PER_DAY' => $current_order['uri'][5],
    'O_EARNED_PER_RAID' => $current_order['uri'][6],
    'O_SPENT' => $current_order['uri'][7],
    'O_SPENT_PER_DAY' => $current_order['uri'][8],
    'O_SPENT_PER_RAID' => $current_order['uri'][9],
    'O_LOST_TO_ADJUSTMENT' => $current_order['uri'][10],
    'O_LOST_TO_SPENT' => $current_order['uri'][11],
    'O_CURRENT' => $current_order['uri'][12],

    'U_STATS' => 'stats.php'.$SID.'&amp;',

    'SHOW' => ( isset($_GET['show']) ) ? $_GET['show'] : '',

    'STATS_FOOTCOUNT' => $footcount_text)
);

$eqdkp->set_vars(array(
    'page_title'    => sprintf($user->lang['title_prefix'], $eqdkp->config['guildtag'], $eqdkp->config['dkp_name']).': '.sprintf($user->lang['stats_title'], $eqdkp->config['dkp_name']),
    'template_file' => 'stats.html',
    'display'       => true)
);
?>
