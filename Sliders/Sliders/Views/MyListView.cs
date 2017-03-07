using System;
using System.Collections.Generic;
using System.Linq;

using iFactr.Core;
using iFactr.Core.Utilities;
using iFactr.UI;
using iFactr.UI.Controls;

namespace Sliders.Views
{
    // TODO: Change the generic type to the type of your model.
    class MyListView : ListView<string>
    {
        /// <summary>
        /// Called when the view is ready to be rendered.
        /// </summary>
        protected override void OnRender()
        {
            // TODO: Set the item count to the desired number of cells in the list.
            Sections[0].ItemCount = 1;
        }

        /// <summary>
        /// Called when a cell is ready to be rendered on the screen.  Return the ICell instance
        /// that should be placed at the given index within the given section.
        /// </summary>
        /// <param name="section">The section that will contain the cell.</param>
        /// <param name="index">The index at which the cell will be placed in the section.</param>
        /// <param name="recycledCell">An already instantiated cell that is ready for reuse, or null if no cell has been recycled.</param>
        protected override ICell OnCellRequested(int section, int index, ICell recycledCell)
        {
            // On platforms that support cell recycling (Android and iOS), recycledCell is passed-in, otherwise is null.
            // In any case, a cell must be returned.
            GridCell cell = recycledCell as GridCell;
            if (cell == null)
            {
                cell = new GridCell();
                cell.Columns.Add(Column.AutoSized);
                cell.Columns.Add(Column.AutoSized);
            }
            Label firstLabel = cell.GetOrCreateChild<Label>("firstLabelID");
            firstLabel.Text = "Data:";
            Label secondLabel = cell.GetOrCreateChild<Label>("secondLabelID");
            secondLabel.Text = Model;

            return cell;
        }

        /// <summary>
        /// Called when a reuse identifier is needed for a cell or tile.  Return the identifier that should be used
        /// to determine which cells or tiles may be reused for the item at the given index within the given section.
        /// This is only called on platforms that support recycling.  See Remarks for details.
        /// </summary>
        /// <param name="section">The section that will contain the item.</param>
        /// <param name="index">The index at which the item will be placed in the section.</param>
        protected override int OnItemIdRequested(int section, int index)
        {
            return index;
        }
    }
}
