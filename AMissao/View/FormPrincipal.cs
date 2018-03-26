using AMissao.Model.Enemies;
using AMissao.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AMissao
{
    public partial class FormPrincipal : Form
    {
        private Game game;
        private Random random = new Random();

        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipalLoad(object sender, EventArgs e)
        {
            game = new Game(new Rectangle(78, 57, 420, 155));
            game.NewLevel(random);
            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            pictureBoxPlayer.Location = game.PlayerLocation;
            labelPlayerHitPoints.Text = game.PlayerHitPoints.ToString();

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;

            foreach (Enemy enemy in game.Enemies)
            {
                if (enemy is Bat)
                {
                    pictureBoxBat.Location = enemy.Location;
                    labelBatHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghost)
                {
                    pictureBoxGhost.Location = enemy.Location;
                    labelGhostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                else if (enemy is Ghoul)
                {
                    pictureBoxGhoul.Location = enemy.Location;
                    labelGhoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }
                else
                {
                    continue;
                }
            }

            switch (showBat)
            {
                case true:
                    pictureBoxBat.Visible = true;
                    break;
                case false:
                    pictureBoxBat.Visible = false;
                    labelBatHitPoints.Text = String.Empty;
                    break;
            }
            switch (showGhost)
            {
                case true:
                    pictureBoxGhost.Visible = true;
                    break;
                case false:
                    pictureBoxGhost.Visible = false;
                    labelGhostHitPoints.Text = String.Empty;
                    break;
            }
            switch (showGhoul)
            {
                case true:
                    pictureBoxGhoul.Visible = true;
                    break;
                case false:
                    pictureBoxGhoul.Visible = false;
                    labelGhoulHitPoints.Text = String.Empty;
                    break;
            }

            CheckWeaponsFalse();
            Control weaponControl = null;

            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = pictureBoxSword;
                    break;
                case "Bow":
                    weaponControl = pictureBoxBow;
                    break;
                case "Mace":
                    weaponControl = pictureBoxMace;
                    break;
                case "Red Potion":
                    weaponControl = pictureBoxRedPotion;
                    break;
                case "Blue Potion":
                    weaponControl = pictureBoxBluePotion;
                    break;
            }

            CheckInventoryFalse();

            if (game.CheckPlayerInventory("Sword"))
            {
                pictureBoxInventory1.Visible = true;
                pictureBoxInventory1.Enabled = true;
                pictureBoxInventory1.Image = Resources.sword;
            }
            if (game.CheckPlayerInventory("Bow"))
            {
                pictureBoxInventory2.Visible = true;
                pictureBoxInventory2.Enabled = true;
                pictureBoxInventory2.Image = Resources.bow;
            }
            if (game.CheckPlayerInventory("Mace"))
            {
                pictureBoxInventory3.Visible = true;
                pictureBoxInventory3.Enabled = true;
                pictureBoxInventory3.Image = Resources.mace;
            }
            if (game.CheckPlayerInventory("Blue Potion"))
            {
                pictureBoxInventory4.Visible = true;
                pictureBoxInventory4.Enabled = true;
                pictureBoxInventory4.Image = Resources.potion_blue;
            }
            if (game.CheckPlayerInventory("Red Potion"))
            {
                pictureBoxInventory5.Visible = true;
                pictureBoxInventory5.Enabled = true;
                pictureBoxInventory5.Image = Resources.potion_red;
            }

            weaponControl.Location = game.WeaponInRoom.Location;
            if (game.WeaponInRoom.PickedUp)
                weaponControl.Visible = false;
            else
                weaponControl.Visible = true;

            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show(@"Você morreu!");
                Application.Exit();
            }
            if (enemiesShown < 1 && game.Level < 8)
            {
                MessageBox.Show(@"Você derrotou os inimigos da dangeon!");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void CheckWeaponsFalse()
        {
            pictureBoxSword.Visible = false;
            pictureBoxBow.Visible = false;
            pictureBoxMace.Visible = false;
            pictureBoxBluePotion.Visible = false;
            pictureBoxRedPotion.Visible = false;
        }

        private void CheckInventoryFalse()
        {
            pictureBoxInventory1.Visible = false;
            pictureBoxInventory1.Enabled = false;
            pictureBoxInventory2.Visible = false;
            pictureBoxInventory2.Enabled = false;
            pictureBoxInventory3.Visible = false;
            pictureBoxInventory3.Enabled = false;
            pictureBoxInventory4.Visible = false;
            pictureBoxInventory4.Enabled = false;
            pictureBoxInventory5.Visible = false;
            pictureBoxInventory5.Enabled = false;
        }

        private void buttonMoveUp_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void buttonMoveDown_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void buttonMoveLeft_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void buttonMoveRight_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void buttonAttackUp_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void buttonAttackDown_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }

        private void buttonAttackLeft_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void buttonAttackRight_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void pictureBoxInventory1_Click(object sender, EventArgs e)
        {
            game.Equip("Sword");
            pictureBoxInventory1.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxInventory2.BorderStyle = BorderStyle.None;
            pictureBoxInventory3.BorderStyle = BorderStyle.None;
            pictureBoxInventory4.BorderStyle = BorderStyle.None;
            pictureBoxInventory5.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxInventory2_Click(object sender, EventArgs e)
        {
            game.Equip("Bow");
            pictureBoxInventory2.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxInventory1.BorderStyle = BorderStyle.None;
            pictureBoxInventory3.BorderStyle = BorderStyle.None;
            pictureBoxInventory4.BorderStyle = BorderStyle.None;
            pictureBoxInventory5.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxInventory3_Click(object sender, EventArgs e)
        {
            game.Equip("Mace");
            pictureBoxInventory3.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxInventory1.BorderStyle = BorderStyle.None;
            pictureBoxInventory2.BorderStyle = BorderStyle.None;
            pictureBoxInventory4.BorderStyle = BorderStyle.None;
            pictureBoxInventory5.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxInventory4_Click(object sender, EventArgs e)
        {
            game.Equip("Blue Potion");
            pictureBoxInventory4.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxInventory1.BorderStyle = BorderStyle.None;
            pictureBoxInventory2.BorderStyle = BorderStyle.None;
            pictureBoxInventory3.BorderStyle = BorderStyle.None;
            pictureBoxInventory5.BorderStyle = BorderStyle.None;
        }

        private void pictureBoxInventory5_Click(object sender, EventArgs e)
        {
            game.Equip("Blue Potion");
            pictureBoxInventory5.BorderStyle = BorderStyle.FixedSingle;
            pictureBoxInventory1.BorderStyle = BorderStyle.None;
            pictureBoxInventory2.BorderStyle = BorderStyle.None;
            pictureBoxInventory3.BorderStyle = BorderStyle.None;
            pictureBoxInventory4.BorderStyle = BorderStyle.None;
        }
    }
}
